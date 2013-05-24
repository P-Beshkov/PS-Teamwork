using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;

namespace Logic
{
    public static class DBManager
    {
        private static SqlCeConnection dbCon;

        public static void InicializeDB(string connectionString)
        {
            DBManager.dbCon = new SqlCeConnection(connectionString);
            //SqlCeConnection dbCon = new SqlCeConnection(@"Data Source=D:\School\PS-Teamwork\CalorimeterUI\CalorimeterLocal.sdf");
        }

        public static bool IsUsernameValid(string username, string password)
        {            
            dbCon.Open();
            using (dbCon)
            {
                SqlCeCommand command = new SqlCeCommand("SELECT * FROM Products", dbCon);
                SqlCeDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string category = (string)reader["Category"];
                        string productName = (string)reader["ProductName"];
                        float calories = (float)reader["Calories"];
                    }
                }

            }
            throw new NotImplementedException();
        }

        internal static List<DailyHistory> LoadUserData(string username,out UserType status)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}