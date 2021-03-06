﻿namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
        private string nickname;
        private string password;
        private string name;
        private UserType type;
        private string email;

        public List<DailyHistory> History
        {
            get
            {
                return this.history;
            }
            set
            {
                this.history = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }

        public UserType Type
        {
            get { return type; }
            set { this.type = value; }
        }

        public string Nickname
        {
            get { return nickname; }
            set { this.nickname = value; }
        }

        public User()
        {

        }
        public User(string nickname, string password, string name,
            string email,  List<DailyHistory> history, UserType type = UserType.User)
        {
            this.Nickname = nickname;
            this.Password = password;
            this.Name = name;
            this.Email = email;
            this.history = history;
            this.Type = type;
        }
    }
}