using System;
using System.Collections.Generic;

namespace Logic
{
    public static class DBManager
    {
        public static bool IsUsernameValid(string username, string password)
        {
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