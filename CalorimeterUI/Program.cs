using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using CalorimeterUI.View;
using System.Text;
using System.IO;
using System.Globalization;
using Logic;

namespace CalorimeterUI
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Already added
            //InsertHistory();
            //InserDailyHistory();
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalorimeterUI());
        }
  
        private static void InserDailyHistory()
        {
            SqlCeConnection dbCon = new SqlCeConnection("Data Source=..\\..\\CalorimeterLocal.sdf");
            using (dbCon)
            {
                dbCon.Open();
                int productId = 1;
                Random random = new Random();
                for (int id = 1; id <= 35; id++)
                {
                    StringBuilder sqlCommand = new StringBuilder();

                    sqlCommand.Append("INSERT INTO DailyHistory (Id, ProductName, Quantity, Calories, HistoryId) VALUES (");
                    sqlCommand.Append(productId.ToString() + ",");
                    int productIndex = random.Next(1, ApplicationLogic.meat.availableProducts.Count);
                    sqlCommand.Append("'" + ApplicationLogic.meat.availableProducts[productIndex].name + "',");
                    int quantity = random.Next(50, 300);
                    sqlCommand.Append(quantity + ", ");
                    decimal calories = ApplicationLogic.meat.availableProducts[productIndex].calories * quantity * 0.01M;
                    sqlCommand.Append(calories + ", ");
                    sqlCommand.Append(id + ")");
                    SqlCeCommand cmd = new SqlCeCommand(sqlCommand.ToString(), dbCon);
                    cmd.ExecuteNonQuery();
                    productId++;

                    sqlCommand = new StringBuilder();
                    sqlCommand.Append("INSERT INTO DailyHistory (Id, ProductName, Quantity, Calories, HistoryId) VALUES (");
                    sqlCommand.Append(productId.ToString() + ",");
                    productIndex = random.Next(1, ApplicationLogic.fruit.availableProducts.Count);
                    sqlCommand.Append("'" + ApplicationLogic.fruit.availableProducts[productIndex].name + "',");
                    quantity = random.Next(50, 300);
                    sqlCommand.Append(quantity + ", ");
                    calories = ApplicationLogic.fruit.availableProducts[productIndex].calories * quantity * 0.01M;
                    sqlCommand.Append(calories + ", ");
                    sqlCommand.Append(id + ")");
                    cmd = new SqlCeCommand(sqlCommand.ToString(), dbCon);
                    cmd.ExecuteNonQuery();
                    productId++;

                    sqlCommand = new StringBuilder();
                    sqlCommand.Append("INSERT INTO DailyHistory (Id, ProductName, Quantity, Calories, HistoryId) VALUES (");
                    sqlCommand.Append(productId.ToString() + ",");
                    productIndex = random.Next(1, ApplicationLogic.cereals.availableProducts.Count);
                    sqlCommand.Append("'" + ApplicationLogic.cereals.availableProducts[productIndex].name + "',");
                    quantity = random.Next(50, 300);
                    sqlCommand.Append(quantity + ", ");
                    calories = ApplicationLogic.cereals.availableProducts[productIndex].calories * quantity * 0.01M;
                    sqlCommand.Append(calories + ", ");
                    sqlCommand.Append(id + ")");
                    cmd = new SqlCeCommand(sqlCommand.ToString(), dbCon);
                    cmd.ExecuteNonQuery();
                    productId++;

                    sqlCommand = new StringBuilder();
                    sqlCommand.Append("INSERT INTO DailyHistory (Id, ProductName, Quantity, Calories, HistoryId) VALUES (");
                    sqlCommand.Append(productId.ToString() + ",");
                    productIndex = random.Next(1, ApplicationLogic.softDrinks.availableProducts.Count);
                    sqlCommand.Append("'" + ApplicationLogic.softDrinks.availableProducts[productIndex].name + "',");
                    quantity = random.Next(50, 300);
                    sqlCommand.Append(quantity + ", ");
                    calories = ApplicationLogic.softDrinks.availableProducts[productIndex].calories * quantity;
                    sqlCommand.Append(calories + ", ");
                    sqlCommand.Append(id + ")");
                    cmd = new SqlCeCommand(sqlCommand.ToString(), dbCon);
                    cmd.ExecuteNonQuery();
                    productId++;
                }
            }
        }
  
        private static void InsertHistory()
        {
            SqlCeConnection dbCon = new SqlCeConnection("Data Source=..\\..\\CalorimeterLocal.sdf");
            using (dbCon)
            {
                dbCon.Open();

                using (StreamReader reader = new StreamReader("..\\..\\CaloriesHystory.txt", Encoding.UTF8))
                {
                    string line = reader.ReadLine();
                    int id = 1;
                    while (line != null)
                    {
                        string[] elements = line.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
                        StringBuilder sqlCommand = new StringBuilder();
                        sqlCommand.Append("INSERT INTO History (Id, Data, DailyCalories, UserName) VALUES (");
                        sqlCommand.Append(id.ToString() + ",");
                        id++;
                        DateTime date = DateTime.ParseExact(elements[0], "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        string dateString = date.ToShortDateString();
                        sqlCommand.Append("'" + dateString + "',");
                        sqlCommand.Append(decimal.Parse(elements[1]).ToString() + ", ");
                        sqlCommand.Append("'Admin')");
                        SqlCeCommand cmd = new SqlCeCommand(sqlCommand.ToString(), dbCon);
                        cmd.ExecuteNonQuery();
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}