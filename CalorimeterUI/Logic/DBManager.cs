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
            using (dbCon)
            {
                dbCon.Open();
               
                string sqlCommand = @"SELECT UserName, Password
                                    FROM     Users
                                    WHERE  UserName = '"+username+"' AND Password = '"+password+"'";
                SqlCeCommand command = new SqlCeCommand(sqlCommand, dbCon);
                SqlCeDataReader reader = command.ExecuteReader();
               
                using (reader)
                {
                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        internal static List<DailyHistory> LoadUserData(string username, out UserType status)
        {
            using (dbCon)
            {
                dbCon.Open();
                //string sqlCommand = 
            }
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