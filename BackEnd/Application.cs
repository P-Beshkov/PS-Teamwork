using System;

namespace Calorimeter_Form
{
    //TODO: Is null parsed as null;
    public static class ApplicationLogic
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
            user = new User("Winnie the Pooh");
        }

        public static void AddNewNutrition(NutritionData item, string typeString)
        {
            TypeFood type = (TypeFood)Enum.Parse(typeof(TypeFood), typeString);

            switch (type)
            {
                case TypeFood.Meat: meat.AddNewNutrution(item);
                    break;
                case TypeFood.Fruit: fruit.AddNewNutrution(item);
                    break;
                case TypeFood.Nuts: nuts.AddNewNutrution(item);
                    break;
                case TypeFood.Vegetables: vegetables.AddNewNutrution(item);
                    break;
                case TypeFood.Fish: fish.AddNewNutrution(item);
                    break;
                case TypeFood.Cereals: cereals.AddNewNutrution(item);
                    break;
                case TypeFood.Bread: bread.AddNewNutrution(item);
                    break;
                case TypeFood.Alchohol: alchohol.AddNewNutrution(item);
                    break;
                case TypeFood.SoftDrinks: softDrinks.AddNewNutrution(item);
                    break;
            }
        }
        
        public static void AddEatenNutrition(NutritionData item, string type, int amount)
        {
            decimal preciseAmount =(decimal) (amount * 0.01);
            user.AddToHistory(item);
            user.Calories += preciseAmount * item.calories;
        }
    }
}
