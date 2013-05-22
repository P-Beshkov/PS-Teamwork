using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Logic
{
    struct EatenData
    {
        string productName;
        int quantity;
        int calories;
    }

    public struct DailyHistory
    {
        List<EatenData> eatenHistory;
        DateTime date;
        decimal dailyCalories;
    }

    public class User// : IUserActions
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
        //private decimal calories;
        //private List<NutritionData> history;
        //private string name;
        //private int loadedItems;
        //private List<Tuple<DateTime, decimal>> caloriesHistory;

        //public decimal Calories
        //{
        //    get
        //    {
        //        return this.calories;
        //    }
        //    set
        //    {
        //        if (value < 0)
        //        {
        //            throw new ArgumentOutOfRangeException("Calories must be positive");
        //        }
        //        this.calories = value;
        //    }
        //}

        //public string Name
        //{
        //    get
        //    {
        //        return this.name;
        //    }
        //    private set
        //    {
        //        this.name = value;
        //    }
        //}

        //public User(string name)
        //{
        //    this.Calories = 0;
        //    this.Name = name;
        //    this.loadedItems = 0;
        //    this.history = new List<NutritionData>();
        //    this.caloriesHistory = new List<Tuple<DateTime, decimal>>();
        //    this.LoadHistory();
        //    this.LoadCaloriesHistory();
        //}

        //private void LoadCaloriesHistory()
        //{
        //    using (StreamReader reader = new StreamReader("..\\..\\CaloriesHystory.txt", Encoding.UTF8))
        //    {                
        //        string line = reader.ReadLine();
        //        while (line != null)
        //        {
        //            string[] elements = line.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
        //            this.caloriesHistory.Add(new Tuple<DateTime, decimal>(DateTime.Parse(elements[0]), decimal.Parse(elements[1])));
        //            line = reader.ReadLine();
        //        }
        //    }
        //    if (DateTime.Now.Date == this.caloriesHistory[this.caloriesHistory.Count - 1].Item1)
        //    {
        //        this.Calories = this.caloriesHistory[this.caloriesHistory.Count - 1].Item2;
        //    }
        //    else
        //    {
        //        this.caloriesHistory.Add(new Tuple<DateTime, decimal>(DateTime.Now.Date, 0));
        //    }
        //}

        //private void SaveCaloriesHistory()
        //{
        //    this.caloriesHistory[this.caloriesHistory.Count - 1] = new Tuple<DateTime, decimal>(DateTime.Now.Date, this.Calories);
        //    using (StreamWriter writer = new StreamWriter("..\\..\\CaloriesHystory.txt", false, Encoding.UTF8))
        //    {
        //        foreach (var item in caloriesHistory)
        //        {
        //            writer.WriteLine(item.Item1.Date + "^" + item.Item2);
        //        }
        //    }
        //}

        //public void SaveHistory()
        //{
        //    string filePath = "..\\..\\" + this.Name + ".txt";
        //    using (StreamWriter writer = new StreamWriter(filePath, true, Encoding.UTF8))
        //    {
        //        for (int i = this.loadedItems - 1; i < this.history.Count; i++)
        //        {
        //            writer.WriteLine("{0}^{1}^{2}^{3}^{4}", this.history[i].name, this.history[i].calories,
        //                this.history[i].carbohydrates, this.history[i].fat, this.history[i].protein);
        //            this.loadedItems++;
        //        }
        //    }
        //    this.SaveCaloriesHistory();
        //}

        //public void LoadHistory()
        //{
        //    string filePath = "..\\..\\" + this.Name + ".txt";
        //    using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
        //    {
        //        string line = "Nothing read";

        //        line = reader.ReadLine();
        //        while (line != null)
        //        {
        //            string[] elements = line.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
        //            NutritionData newProduct = new NutritionData();
        //            newProduct.name = elements[0];
        //            newProduct.calories = int.Parse(elements[1]);
        //            newProduct.carbohydrates = float.Parse(elements[2]);
        //            newProduct.fat = float.Parse(elements[3]);
        //            newProduct.protein = float.Parse(elements[4]);
        //            this.Calories += newProduct.calories;
        //            this.history.Add(newProduct);
        //            this.loadedItems++;
        //            line = reader.ReadLine();
        //        }
        //        this.loadedItems++;
        //    }
        //}

        //public void AddToHistory(NutritionData item)
        //{
        //    this.history.Add(item);
        //    if (DateTime.Now.Date == this.caloriesHistory[this.caloriesHistory.Count - 1].Item1)
        //    {
        //        this.calories = this.caloriesHistory[this.caloriesHistory.Count - 1].Item2;
        //    }
        //}

        //public List<Tuple<DateTime, decimal>> GetElements(int wanted)
        //{
        //    List<Tuple<DateTime, decimal>> result = new List<Tuple<DateTime, decimal>>();
        //    if (wanted >= this.caloriesHistory.Count)
        //    {
        //        foreach (var item in this.caloriesHistory)
        //        {
        //            result.Add(item);
        //        }
        //        return result;
        //    }
        //    int available = this.caloriesHistory.Count;
        //    for (int index = available - wanted; index < available; index++)
        //    {
        //        result.Add(this.caloriesHistory[index]);
        //    }
        //    return result;
        //}

        //public string ShowDetailedHistory()
        //{
        //    StringBuilder temp = new StringBuilder();
        //    for (int i = 0; i < this.history.Count; i++)
        //    {
        //        temp.AppendFormat("{0} {1} {2} {3} {4}\n", this.history[i].name, this.history[i].calories,
        //            this.history[i].carbohydrates, this.history[i].fat, this.history[i].protein);
        //    }
        //    return temp.ToString();
        //}


        internal void AddEatenFood(DateTime dateTime, string p, int value)
        {
            throw new NotImplementedException();
        }
    }
}