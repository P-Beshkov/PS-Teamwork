using System;
using System.Collections.Generic;

namespace Logic
{
    public class ApplicationLogic
    {
        public static Meat meat;
        public static Fruits fruit;
        public static Nuts nuts;
        public static Vegetables vegetables;
        public static Fish fish;
        public static Cereals cereals;
        public static Bread bread;
        public static Alchohol alchohol;
        public static SoftDrinks softDrinks;
        public static User user;

        static ApplicationLogic()
        {
            meat = new Meat();
            fruit = new Fruits();
            nuts = new Nuts();
            vegetables = new Vegetables();
            fish = new Fish();
            cereals = new Cereals();
            bread = new Bread();
            alchohol = new Alchohol();
            softDrinks = new SoftDrinks();
            //user = logicForm        
        }

        public static void Save()
        {
            meat.SaveProducts();
            fruit.SaveProducts();
            nuts.SaveProducts();
            vegetables.SaveProducts();
            fish.SaveProducts();
            cereals.SaveProducts();
            bread.SaveProducts();
            alchohol.SaveProducts();
            softDrinks.SaveProducts();
            //user.SaveHistory();            
        }

        public static void AddNewNutrition(NutritionData item, string typeString)
        {
            TypeFood type = (TypeFood)Enum.Parse(typeof(TypeFood), typeString);            
            switch (type)
            {
                case TypeFood.Meat:
                    meat.AddNewNutrution(item);
                    break;
                case TypeFood.Fruit:
                    fruit.AddNewNutrution(item);
                    break;
                case TypeFood.Nuts:
                    nuts.AddNewNutrution(item);
                    break;
                case TypeFood.Vegetables:
                    vegetables.AddNewNutrution(item);
                    break;
                case TypeFood.Fish:
                    fish.AddNewNutrution(item);
                    break;
                case TypeFood.Cereals:
                    cereals.AddNewNutrution(item);
                    break;
                case TypeFood.Bread:
                    bread.AddNewNutrution(item);
                    break;
                case TypeFood.Alchohol:
                    alchohol.AddNewNutrution(item);
                    break;
                case TypeFood.SoftDrinks:
                    softDrinks.AddNewNutrution(item);
                    break;
                default:
                    throw new TypeFoodException("This type food is not implemented"); 
            }
        }

        public static void AddEatenNutrition(string typeString, string nutritionName, int amount)
        {
            TypeFood type = (TypeFood)Enum.Parse(typeof(TypeFood), typeString);
            NutritionData newItem = new NutritionData();
            switch (type)
            {
                case TypeFood.Meat:
                    newItem = meat.SearchItem(nutritionName);
                    break;
                case TypeFood.Fruit:
                    newItem = fruit.SearchItem(nutritionName);
                    break;
                case TypeFood.Nuts:
                    newItem = nuts.SearchItem(nutritionName);
                    break;
                case TypeFood.Vegetables:
                    newItem = vegetables.SearchItem(nutritionName);
                    break;
                case TypeFood.Fish:
                    newItem = fish.SearchItem(nutritionName);
                    break;
                case TypeFood.Cereals:
                    newItem = cereals.SearchItem(nutritionName);
                    break;
                case TypeFood.Bread:
                    newItem = bread.SearchItem(nutritionName);
                    break;
                case TypeFood.Alchohol:
                    newItem = alchohol.SearchItem(nutritionName);
                    break;
                case TypeFood.SoftDrinks:
                    newItem = softDrinks.SearchItem(nutritionName);
                    break;
                default:
                    throw new TypeFoodException("This type food is not implemented");                    
            }
            decimal preciseAmount = (decimal)(amount * 0.01);
            //user.AddToHistory(newItem);
            //user.Calories += preciseAmount * newItem.calories;
        }

        public static List<string> GetItemsString(TypeFood type)
        {
            List<string> buffer = new List<string>();
            switch (type)
            {
                case TypeFood.Meat:
                    foreach (var item in meat)                    
                        buffer.Add(item.name);                    
                    break;
                case TypeFood.Fruit:
                    foreach (var item in fruit)
                        buffer.Add(item.name);
                    break;
                case TypeFood.Nuts:
                    foreach (var item in nuts)
                        buffer.Add(item.name);
                    break;
                case TypeFood.Vegetables:
                    foreach (var item in vegetables)
                        buffer.Add(item.name);
                    break;
                case TypeFood.Fish:
                    foreach (var item in fish)
                        buffer.Add(item.name);
                    break;
                case TypeFood.Cereals:
                    foreach (var item in cereals)
                        buffer.Add(item.name);
                    break;
                case TypeFood.Bread:
                    foreach (var item in bread)
                        buffer.Add(item.name);
                    break;
                case TypeFood.Alchohol:
                    foreach (var item in alchohol)
                        buffer.Add(item.name);
                    break;
                case TypeFood.SoftDrinks:
                    foreach (var item in softDrinks)
                        buffer.Add(item.name);
                    break;
                default:
                    throw new TypeFoodException("This type food is not implemented"); 
            }
            return buffer;
        }

        public static List<Tuple<DateTime, decimal>> ShowLastWeek()
        {
            //throw new NotImplementedException();
            int daysBefore = 7;
            return DBManager.LoadHistory(daysBefore);
            //return user.GetElements(7);
        }

        public static List<Tuple<DateTime, decimal>> ShowLastMonth()
        {
            int daysBefore = 30;
            return DBManager.LoadHistory(daysBefore);
            throw new NotImplementedException();
            //return user.GetElements(30);
        }
    }
}