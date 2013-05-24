using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;

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
                            if (isDateEqual==false)
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
            throw new NotImplementedException();
        }

        internal static void RegisterUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        internal static void AddEatenFood(System.Windows.Forms.Label currentUserName, DateTime dateTime, string p, int value)
        {
            throw new NotImplementedException();
        }

        internal static void AddNewFood(NutritionData item)
        {
            throw new NotImplementedException();
        }

        internal static List<String> LoadProducts(TypeFood typeFood)
        {
            string sqlCommandString = @"SELECT ProductName, Category
                FROM     Products
                WHERE  (Category = N'"+typeFood.ToString()+"')";
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
    }
}