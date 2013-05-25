using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Logic
{
    public struct EatenData
    {
        public string productName;
        public int quantity;
        public decimal calories;
    }

    public struct DailyHistory
    {
        public List<EatenData> eatenHistory;
        public string date;
        public decimal dailyCalories;
    }

    public class User
    {
        private List<DailyHistory> history;
        private string name;
        private UserType type;

        public UserType Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public User(string name, List<DailyHistory> history, UserType type=UserType.User)
        {
            this.history = history;
            this.Name = name;
            this.Type = type;
        }
    }
}