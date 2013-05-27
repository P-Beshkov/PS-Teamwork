namespace Data
{
    using Logic;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlServerCe;
    using System.Globalization;

    public static class DBManager
    {
        private static SqlCeConnection dbCon;
        private static SqlCeDataAdapter dataAdapter;

        static DBManager()
        {
            DBManager.dbCon = new SqlCeConnection("Data Source=..\\..\\CalorimeterLocal.sdf");            
        }

        internal static void UpdateDailyHistory()
        {
            if (dbCon.State == ConnectionState.Closed)
            {
                dbCon.Open();
            }
            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = dbCon;
            cmd.CommandText = @"SELECT ProductName, Quantity, Id FROM DailyHistory";
            SqlCeDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string productName = (string)reader["ProductName"];
                int id = (int)reader["Id"];
                int quantity = (int)reader["Quantity"];
                if (quantity > 500)
                {
                    quantity -=400;
                    SqlCeCommand innerCmd = new SqlCeCommand();
                    innerCmd.Connection = dbCon;
                    innerCmd.CommandText = String.Format("UPDATE DailyHistory SET Quantity = {0} WHERE Id = {1}", quantity, id);
                    innerCmd.ExecuteNonQuery();
                }
                cmd.CommandText = String.Format("SELECT Calories FROM Products WHERE ProductName='{0}'", productName);
                SqlCeDataReader caloriesReader = cmd.ExecuteReader();
                caloriesReader.Read();
                decimal standartCalories = (decimal)caloriesReader["Calories"];
                decimal calculatedCalories = standartCalories * quantity * 0.01M;

                cmd.CommandText = String.Format(
                    "UPDATE DailyHistory SET Calories = {0} WHERE Id = {1}", calculatedCalories, id);
                cmd.ExecuteNonQuery();
            }

            dbCon.Close();
        }            

        internal static void UpdateHistory()
        {
            SqlCeCommand cmd = new SqlCeCommand();
            if (dbCon.State == ConnectionState.Closed)
            {
                dbCon.Open();
            }
            cmd.Connection = dbCon;
            cmd.CommandText = @"SELECT MAX(Id) FROM History";
            int historyId = (int)cmd.ExecuteScalar();
            for (int i = 1; i <= historyId; i++)
            {
                cmd.CommandText = String.Format(
                    "SELECT SUM(Calories) AS Expr FROM DailyHistory WHERE (HistoryId = {0})", i);
                SqlCeDataReader reader = cmd.ExecuteReader();
                reader.Read();
                decimal newCalories = (Decimal)reader[0];

                cmd.CommandText = String.Format(
                    @"UPDATE History SET DailyCalories = {0} WHERE Id={1}", newCalories, i);
                cmd.ExecuteNonQuery();
            }
            dbCon.Close();
        }

        public static bool IsUsernameValid(string username, string password)
        {
            if (dbCon.State == ConnectionState.Closed)
            {
                dbCon.Open();
            }
            string hashedPassword = HashFunctions.CalculateMD5Hash(password);
            string sqlCommand = String.Format(@"SELECT UserName, Password FROM     Users
                WHERE  UserName = '{0}' AND Password = '{1}'", username, hashedPassword);
            SqlCeCommand command = new SqlCeCommand(sqlCommand, dbCon);
            SqlCeDataReader reader = command.ExecuteReader();

            using (reader)
            {
                bool isValid = false;
                if (reader.Read())
                {
                    // case sensitive
                    string dbUsername = (string)reader["UserName"];
                    if (dbUsername == username)
                    {
                        isValid = true;
                    }
                }
                dbCon.Close();
                return isValid;
            }
        }

        internal static bool IsUernameFree(string username)
        {
            if (dbCon.State == ConnectionState.Closed)
            {
                dbCon.Open();
            }

            string sqlCommand = String.Format(@"SELECT UserName FROM Users WHERE  UserName = '{0}'", username);
            SqlCeCommand command = new SqlCeCommand(sqlCommand, dbCon);
            SqlCeDataReader reader = command.ExecuteReader();

            using (reader)
            {
                bool isFree = true;
                if (reader.Read())
                {
                    isFree = false;
                }

                dbCon.Close();
                return isFree;
            }
        }

        internal static void RegisterUser(string username, string password, string email, string name)
        {
            throw new NotImplementedException("Implement register with name/email");
            if (dbCon.State == ConnectionState.Closed)
            {
                dbCon.Open();
            }
            string hashedPassword = HashFunctions.CalculateMD5Hash(password);
            string cmdString =
                String.Format("INSERT INTO Users(Username, Password, Type) VALUES ('{0}','{1}','{2}')",
                    username, hashedPassword, UserType.User.ToString());
            SqlCeCommand cmd = new SqlCeCommand(cmdString, dbCon);
            cmd.ExecuteNonQuery();
            dbCon.Close();
        }

        internal static User LoadUserData(string username)
        {
            throw new NotImplementedException("Load user with all data.");
            List<DailyHistory> result = new List<DailyHistory>();
            var status = UserType.Anonymous;

            dbCon.Open();
            string sqlCommand = String.Format(
                @"SELECT Users.Type, History.Data, History.DailyCalories, DailyHistory.ProductName, 
                DailyHistory.Quantity, DailyHistory.Calories, Users.UserName FROM DailyHistory 
                    INNER JOIN History ON DailyHistory.HistoryId = History.Id 
                    INNER JOIN Users ON History.UserName = Users.UserName
                WHERE  (Users.UserName = '{0}')", username);
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
            return null;//result;
        }

        internal static void AddEatenFood(string userName, DateTime dateTime, string productName, int quantity)
        {
            if (dbCon.State == ConnectionState.Closed)
            {
                dbCon.Open();
            }

            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = dbCon;
            string sqlCommandString = "SELECT MAX(Id)+1 FROM DailyHistory";
            cmd.CommandText = sqlCommandString;
            int id = (int)cmd.ExecuteScalar();

            cmd.CommandText = String.Format(
                @"SELECT {0}*Calories FROM Products WHERE ProductName = '{1}'", quantity, productName);
            decimal calories = ((decimal)cmd.ExecuteScalar()) * 0.01M;

            string dateTimeString = String.Format("{0}.{1}.{2} ã.", dateTime.Day, dateTime.Month, dateTime.Year);
            cmd.CommandText = String.Format(@"SELECT Id FROM History WHERE Data = '{0}' AND UserName = '{1}'",
                dateTimeString, userName);
            var result = cmd.ExecuteScalar();

            int historyId;
            if (result == null)
            {
                cmd.CommandText = @"SELECT MAX(Id)+1 FROM History";
                historyId = (int)cmd.ExecuteScalar();
                cmd.CommandText = String.Format(
                    @"INSERT INTO History(Id,Data,DailyCalories,UserName) VALUES({0}, '{1}',{2},'{3}')", historyId, dateTimeString, 0M, userName);
                cmd.ExecuteNonQuery();
                dbCon.Close();
                dbCon.Open();
            }
            else
            {
                historyId = (int)result;
            }

            cmd.CommandText = String.Format(
                @"INSERT INTO  DailyHistory (Id, ProductName, Quantity, Calories, HistoryId)
                VALUES ({0},'{1}',{2},{3}, {4})", id, productName, quantity, calories, historyId);
            cmd.ExecuteNonQuery();
            dbCon.Close();
            dbCon.Open();

            cmd.CommandText = String.Format(
                "SELECT SUM(Calories) AS Expr FROM DailyHistory WHERE (HistoryId = {0})", historyId);
            SqlCeDataReader reader = cmd.ExecuteReader();
            reader.Read();
            decimal newCalories = (Decimal)reader[0];

            cmd.CommandText = String.Format(
                @"UPDATE History SET DailyCalories = {0} WHERE Id={1}", newCalories, historyId);
            cmd.ExecuteNonQuery();

            dbCon.Close();            
        }

        internal static void AddNewFood(NutritionData item)
        {
            if (dbCon.State == ConnectionState.Closed)
            {
                dbCon.Open();
            }

            string cmdString = String.Format(
                @"INSERT INTO Products(Category,ProductName,Calories,Fat,Carbohydrates,Proteins) 
                VALUES('{0}','{1}',{2},{3},{4},{5})",
                item.type.ToString(), item.name, item.calories, item.fat, item.carbohydrates, item.protein);
            SqlCeCommand cmd = new SqlCeCommand(cmdString, dbCon);
            cmd.ExecuteNonQuery();

            dbCon.Close();
        }

        internal static List<String> LoadProducts(TypeFood typeFood)
        {
            if (dbCon.State == ConnectionState.Closed)
            {
                dbCon.Open();
            }

            string sqGetAllProductsFromType = @"SELECT ProductName, Category FROM Products
                WHERE  (Category = N'" + typeFood.ToString() + "')";

            SqlCeCommand cmd = new SqlCeCommand(sqGetAllProductsFromType, dbCon);
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
            if (dbCon.State != ConnectionState.Open)
            {
                dbCon.Open();
            }

            List<Tuple<DateTime, decimal>> result = new List<Tuple<DateTime, decimal>>();
            SqlCeCommand cmd = new SqlCeCommand();

            cmd.Connection = dbCon;
            cmd.CommandText = String.Format("SELECT MAX(Id) FROM History WHERE UserName='{0}'", name);
            var cmdResult = cmd.ExecuteScalar();
            if (cmdResult is DBNull)
            {
                return result;
            }
            int maxId = (int)cmdResult;
            int minId = maxId - daysBefore;
            if (minId < 1)
            {
                minId = 1;
            }

            cmd.CommandText = String.Format(
                @"SELECT Data, DailyCalories FROM History WHERE Id>{0} AND UserName='{1}'", minId, name);
            SqlCeDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string dateString = (string)reader["Data"];
                string dateFormat = "d.M.yyyy ã.";
                DateTime date = DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
                result.Add(new Tuple<DateTime, decimal>(
                    date,
                    (decimal)reader["DailyCalories"]));
            }
            dbCon.Close();
            return result;
        }

        internal static void Dispose()
        {
            dbCon.Dispose();
        }

        internal static void GetProductsData(System.Data.DataSet dataSet)
        {
            SqlCeCommandBuilder cmdBldr;
            if (dbCon.State == ConnectionState.Closed)
            {
                dbCon.Open();
            }
            DBManager.dataAdapter = new SqlCeDataAdapter("Select * from Products", dbCon);
            cmdBldr = new SqlCeCommandBuilder(dataAdapter);
            dataAdapter.Fill(dataSet, "Products");
            dbCon.Close();
        }

        internal static void UpdateAdapter(DataSet dataSet, string srcTable)
        {
            if (dbCon.State == ConnectionState.Closed)
            {
                dbCon.Open();
            }
            dataAdapter.Update(dataSet, "Products");
            dbCon.Close();
        }
    }
}