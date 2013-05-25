namespace Logic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Alchohol : Drink
    {
        public Alchohol() : base()
        {
            this.fileLocation = "..\\..\\Data\\Alchohol.txt";
            this.LoadProducts();
        }
    }

    public class Bread : Food
    {
        public Bread()
            : base()
        {
            this.fileLocation = "..\\..\\Data\\Bread.txt";
            this.LoadProducts();
        }
    }

    public class Cereals : Food
    {
        public Cereals()
            : base()
        {
            this.fileLocation = "..\\..\\Data\\Cereals.txt";
            this.LoadProducts();
        }
    }

    public abstract class Drink : Nutrition
    {
        protected Drink()
            : base()
        {
            this.metrics = "milliliters";
        }
    }

    public class Fish : Food
    {
        public Fish()
            : base()
        {
            this.fileLocation = "..\\..\\Data\\Fish.txt";
            this.LoadProducts();
        }
    }

    public abstract class Food : Nutrition
    {
        protected Food()
            : base()
        {
            this.metrics = "gram";
        }

    }

    public class Fruits : Food
    {
        public Fruits()
            : base()
        {
            this.fileLocation = "..\\..\\Data\\Fruits.txt";
            this.LoadProducts();
        }
    }

    public class Meat : Food
    {
        public Meat()
            : base()
        {
            this.fileLocation = "..\\..\\Data\\Meat.txt";
            this.LoadProducts();
        }
    }

    public class Nuts : Food
    {
        public Nuts()
            : base()
        {
            this.fileLocation = "..\\..\\Data\\Nuts.txt";
            this.LoadProducts();
        }
    }

    public class SoftDrinks : Drink
    {
        public SoftDrinks()
            : base()
        {
            this.fileLocation = "..\\..\\Data\\SoftDrinks.txt";
            this.LoadProducts();
        }
    }

    public class Vegetables : Food
    {
        public Vegetables()
            : base()
        {
            this.fileLocation = "..\\..\\Data\\Vegetables.txt";
            this.LoadProducts();
        }
    }

    public abstract class Nutrition : IEnumerable<NutritionData>
    {
        public List<NutritionData> availableProducts;
        protected string fileLocation;
        protected int loadedProducts;
        public string metrics;

        public Nutrition()
        {
            this.fileLocation = "Not specified";
            this.loadedProducts = 0;
            this.metrics = "Not specified";
            this.availableProducts = new List<NutritionData>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<NutritionData> GetEnumerator()
        {
            foreach (var item in this.availableProducts)
            {
                yield return item;
            }
        }
        public IEnumerable GetItemsWithCaloriesLess(int calories)
        {
            IEnumerable result =
                                from token in this.availableProducts
                                where token.calories < calories
                                orderby token.calories
                                select token;
            return result;
        }
        public NutritionData SearchItem(string name)
        {
            NutritionData found = this.availableProducts.Find(
                (item) => { return item.name == name; });
            return found;
        }

        public NutritionData this[int index]
        {
            get
            {
                return this.availableProducts[index];
            }
        }

        public void LoadProducts()
        {
            using (StreamReader reader = new StreamReader(this.fileLocation))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] elements = line.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
                    NutritionData newProduct = new NutritionData();
                    newProduct.name = elements[0];
                    newProduct.protein = decimal.Parse(elements[1]);
                    newProduct.fat = decimal.Parse(elements[2]);
                    newProduct.carbohydrates = decimal.Parse(elements[3]);
                    newProduct.calories = int.Parse(elements[4]);
                    this.availableProducts.Add(newProduct);
                    this.loadedProducts++;
                    line = reader.ReadLine();
                }
            }
            this.availableProducts.Sort();
        }

        public void AddNewNutrution(NutritionData item)
        {
            this.availableProducts.Add(item);
        }

        public void SaveProducts()
        {
            using (StreamWriter writer = new StreamWriter(this.fileLocation, true, Encoding.UTF8))
            {
                for (int i = this.loadedProducts; i < this.availableProducts.Count; i++)
                {
                    string data = String.Format("{0}^{1}^{2}^{3}^{4}", this.availableProducts[i].name,
                        this.availableProducts[i].protein, this.availableProducts[i].fat,
                        this.availableProducts[i].carbohydrates, this.availableProducts[i].calories);
                    writer.WriteLine(data);
                    this.loadedProducts++;
                }
            }
        }

        public string GetProducts()
        {
            StringBuilder temp = new StringBuilder(32);
            for (int i = 0; i < this.availableProducts.Count; i++)
            {
                temp.AppendFormat("{0} {1} {2} {3} {4}\n", this.availableProducts[i].name, this.availableProducts[i].protein,
                    this.availableProducts[i].fat, this.availableProducts[i].carbohydrates, this.availableProducts[i].calories);
            }
            return temp.ToString();
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} items in {2}", this.GetType(), this.availableProducts.Count, this.fileLocation);
        }
    }

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
                    throw new ArgumentException("This type food is not implemented");
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
                    throw new ArgumentException("This type food is not implemented");
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
                    throw new ArgumentException("This type food is not implemented");
            }
            return buffer;
        }

        public static List<Tuple<DateTime, decimal>> ShowLastWeek()
        {
            //throw new NotImplementedException();
            int daysBefore = 7;
            return DBManager.LoadHistory(daysBefore, user.Name);
            //return user.GetElements(7);
        }

        public static List<Tuple<DateTime, decimal>> ShowLastMonth()
        {
            int daysBefore = 30;
            return DBManager.LoadHistory(daysBefore, user.Name);
            throw new NotImplementedException();
            //return user.GetElements(30);
        }
    }
}