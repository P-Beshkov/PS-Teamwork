using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;


namespace BackEnd
{
    public static class ZProgram
    {
        //public static Meat meat = new Meat();
        //public static Fruits fruit = new Fruits();

        //public static void AddNewNutrition(NutritionData item, string typeString)
        //{
        //    TypeFood type = (TypeFood)Enum.Parse(typeof(TypeFood), typeString);
        //    switch (type)
        //    {
        //        case TypeFood.Meat: meat.AddNewNutrution(item);
        //            break;
        //        case TypeFood.Fruit: fruit.AddNewNutrution(item);
        //            break;
                
        //    }
        //}
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            DateTime time = DateTime.Parse("03/20/2013 00:00:00");
            Console.WriteLine(time);
            Console.WriteLine(DateTime.Now.Date);
            //using (StreamReader reader = new StreamReader("..\\..\\Vegetables.txt"))
            //{
            //    string line = reader.ReadLine();
            //    while (line != null)
            //    {
            //        string[] elements = line.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
            //        NutritionData newProduct = new NutritionData();
            //        newProduct.name = elements[0];
            //        newProduct.protein = float.Parse(elements[1]);
            //        newProduct.fat = float.Parse(elements[2]);
            //        newProduct.carbohydrates = float.Parse(elements[3]);
            //        newProduct.calories = int.Parse(elements[4]);
            //        fruit.AddNewNutrution(newProduct);
            //        line = reader.ReadLine();
            //    }
            //}
            ////meat.AddNewNutrution(new NutritionData("Babek", 123, 56, 56, 56));
            ////meat.SaveProducts();
            //foreach (NutritionData item in fruit)
            //{
            //    Console.WriteLine(item.name + " " + item.calories);
            //}
        }
        //public static void WriteToDB(NutritionData nutrition, string text)
        //{
        //    using (StreamWriter writer = new StreamWriter(@"..\..\test.txt", true))
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append(text);
        //        //sb.Append("\r\n");
        //        //sb.Append(nutrition.name);
        //        //sb.Append("\r\n");
        //        //sb.Append(nutrition.calories);
        //        //sb.Append("\r\n");
        //        //sb.Append(nutrition.carbohydrates);
        //        //sb.Append("\r\n");
        //        //sb.Append(nutrition.fat);
        //        //sb.Append("\r\n");
        //        //sb.Append(nutrition.protein);
        //        //sb.Append("\r\n");
        //        //sb.Append("----------");
        //        writer.WriteLine(sb.ToString());
        //    }
        //}
        //public static List<string> ReadNamesFromDB()
        //{
        //    List<string> output = new List<string>();
        //    using (StreamReader reader = new StreamReader(@"..\..\test.txt"))
        //    {
        //        while (!reader.EndOfStream)
        //        {
        //            string line = reader.ReadLine();
        //            if (line == "Meat")
        //            {
        //                line = reader.ReadLine();
        //                output.Add(line);
        //            }
        //        }   
        //    }
        //    return output;
        //}
    }
}