using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Globalization;

namespace Logic
{
    public static class DBManager
    {
        private static SqlCeConnection dbCon;

        //SqlCeConnection dbCon = new SqlCeConnection(@"Data Source=..\\..\\CalorimeterLocal.sdf");
        static DBManager()
        {
            DBManager.dbCon = new SqlCeConnection("Data Source=..\\..\\CalorimeterLocal.sdf");
        }

        public static bool IsUsernameValid(string username, string password)
        {
            dbCon.Open();
            string sqlCommand = @"SELECT UserName, Password
                                    FROM     Users
                                    WHERE  UserName = '" + username + "' AND Password = '" + password + "'";
            SqlCeCommand command = new SqlCeCommand(sqlCommand, dbCon);
            SqlCeDataReader reader = command.ExecuteReader();

            using (reader)
            {
                if (reader.Read())
                {
                    dbCon.Close();
                    return true;
                }
                else
                {
                    dbCon.Close();
                    return false;
                }
            }

        }

        internal static List<DailyHistory> LoadUserData(string username, out UserType status)
        {
            List<DailyHistory> result = new List<DailyHistory>();
            status = UserType.Anonymous;

            dbCon.Open();
            string sqlCommand = @"SELECT Users.Type, History.Data, History.DailyCalories, DailyHistory.ProductName, DailyHistory.Quantity, DailyHistory.Calories, Users.UserName
                    FROM     DailyHistory INNER JOIN
                    History ON DailyHistory.HistoryId = History.Id INNER JOIN
                    Users ON History.UserName = Users.UserName
                    WHERE  (Users.UserName = '" + username + "')";
            SqlCeCommand command = new SqlCeCommand(sqlCommand, dbCon);
            SqlCeDataReader reader = command.ExecuteReader();

            using (reader)
            {

                while (reader.Read())
                {
                    status = (UserType)Enum.Parse(typeof(UserType), (string)reader["Type"]);
                    DailyHistory daily = new DailyHistory()
                    {
                        eatenHistory = new List<EatenData>(),
                        date = (string)reader["Data"],
                        dailyCalories = (decimal)reader["DailyCalories"]
                    };
                    bool isDateEqual;
                    bool readMore;
                    do
                    {
                        EatenData eaten = new EatenData()
                        {
                            productName = (string)reader["ProductName"],
                            quantity = (int)reader["Quantity"],
                            calories = (decimal)reader["Calories"]
                        };
                        daily.eatenHistory.Add(eaten);
                        readMore = reader.Read();
                        if (readMore)
                        {
                            isDateEqual = (string)reader["Data"] == daily.date;
                            if (isDateEqual == false)
                            {
                                isDateEqual = true;
                                result.Add(daily);
                                daily = new DailyHistory()
                                {
                                    eatenHistory = new List<EatenData>(),
                                    date = (string)reader["Data"],
                                    dailyCalories = (decimal)reader["DailyCalories"]
                                };

                            }
                        }
                        else
                        {
                            result.Add(daily);
                            isDateEqual = false;
                        }

                    }
                    while (readMore && isDateEqual);

                }

            }
            dbCon.Close();

            return result;
        }

        internal static bool IsUernameFree(string username)
        {

            dbCon.Open();

            string sqlCommand = @"SELECT UserName
                                    FROM     Users
                                    WHERE  UserName = '" + username + "'";
            SqlCeCommand command = new SqlCeCommand(sqlCommand, dbCon);
            SqlCeDataReader reader = command.ExecuteReader();

            using (reader)
            {
                if (reader.Read())
                {
                    dbCon.Close();
                    return false;
                }
                else
                {
                    dbCon.Close();
                    return true;
                }
            }
        }

        internal static void RegisterUser(string username, string password)
        {
            dbCon.Open();
            string cmdString =
                String.Format("INSERT INTO Users(Username, Password, Type) VALUES ('{0}','{1}','{2}')",
                username, password, UserType.User.ToString());
            SqlCeCommand cmd = new SqlCeCommand(cmdString, dbCon);
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }

        internal static void AddEatenFood(string UserName, DateTime dateTime, string productName, int quantity)
        {
            dbCon.Open();

            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = dbCon;
            string sqlCommandString = "SELECT MAX(Id)+1 FROM DailyHistory";
            cmd.CommandText = sqlCommandString;
            int id = (int)cmd.ExecuteScalar();

            cmd.CommandText = String.Format(
                @"SELECT {0}*Calories FROM Products WHERE ProductName = '{1}'",quantity,productName);
            decimal calories = ((decimal)cmd.ExecuteScalar())*0.01M;
            string dateTimeString = String.Format("{0}.{1}.{2} ã.",
                dateTime.Day,dateTime.Month,dateTime.Year);
            cmd.CommandText = String.Format(
                @"SELECT Id FROM History WHERE Data = '{0}' AND UserName = '{1}'",dateTimeString,UserName);
            var result = cmd.ExecuteScalar();
            int historyId;
            if (result == null)
            {
                cmd.CommandText = @"SELECT MAX(Id)+1 FROM History";
                historyId = (int)cmd.ExecuteScalar();
                cmd.CommandText = String.Format(
                    @"INSERT INTO History(Id,Data,DailyCalories,UserName) VALUES({0}, '{1}',{2},'{3}')", historyId, dateTimeString, 0M, UserName);
                cmd.ExecuteNonQuery();
                dbCon.Close();
                dbCon.Open();
            }
            else
            {
                historyId = (int)result;
            }
            cmd.CommandText =String.Format(
                @"INSERT INTO  DailyHistory (Id, ProductName, Quantity, Calories, HistoryId)
                VALUES ({0},'{1}',{2},{3}, {4})"
                , id, productName, quantity, calories, historyId);
            cmd.ExecuteNonQuery();
            dbCon.Close();
            dbCon.Open();
            cmd.CommandText = String.Format("SELECT SUM(Calories) AS Expr FROM DailyHistory WHERE (HistoryId = {0})", historyId);
            var reader = cmd.ExecuteReader();
            decimal newCalories;
            reader.Read();
            newCalories = (Decimal)reader[0];
            cmd.CommandText = String.Format(@"UPDATE History SET DailyCalories = {0} WHERE Id={1}",newCalories,historyId);
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }

        internal static void AddNewFood(NutritionData item)
        {
            dbCon.Open();
            string cmdString = String.Format(
                "INSERT INTO Products(Category,ProductName,Calories,Fat,Carbohydrates,Proteins) VALUES('{0}','{1}',{2},{3},{4},{5})",
                item.type.ToString(), item.name, item.calories, item.fat, item.carbohydrates, item.protein);
            SqlCeCommand cmd = new SqlCeCommand(cmdString, dbCon);
            cmd.ExecuteNonQuery();
            dbCon.Close();            
        }

        internal static List<String> LoadProducts(TypeFood typeFood)
        {
            string sqlCommandString = @"SELECT ProductName, Category
                FROM     Products
                WHERE  (Category = N'" + typeFood.ToString() + "')";
            dbCon.Open();
            SqlCeCommand cmd = new SqlCeCommand(sqlCommandString, dbCon);
            SqlCeDataReader reader = cmd.ExecuteReader();
            List<string> result = new List<string>();
            while (reader.Read())
            {
                result.Add((string)reader["ProductName"]);
            }
            dbCon.Close();
            return result;
        }

        internal static List<Tuple<DateTime, decimal>> LoadHistory(int daysBefore, string name)
        {
            List<Tuple<DateTime, decimal>> result = new List<Tuple<DateTime, decimal>>();
            dbCon.Open();
            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = dbCon;

            cmd.CommandText = "SELECT MAX(Id) FROM History";
            int maxId = (int)cmd.ExecuteScalar();
            int minId = maxId - daysBefore;
            if (minId<1)
            {
                minId = 1;
            }
            cmd.CommandText = String.Format(@"SELECT Data, DailyCalories FROM History WHERE Id>{0}", minId);
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string dateString = (string)reader["Data"];
                string dateFormat = "d.M.yyyy ã.";                
                DateTime date = DateTime.ParseExact(dateString, dateFormat,CultureInfo.InvariantCulture);
                result.Add(new Tuple<DateTime, decimal>(date, (decimal)reader["DailyCalories"]));
            }
            dbCon.Close();
            return result;
        }

        internal static void Dispose()
        {
            dbCon.Dispose();
        }
    }
}