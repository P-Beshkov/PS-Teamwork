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
            SqlCeConnection dbCon = new SqlCeConnection("Data Source=..\\..\\CalorimeterLocal.sdf");
            using (dbCon)
            {
                dbCon.Open();
                
                //using (StreamReader reader = new StreamReader("..\\..\\CaloriesHystory.txt", Encoding.UTF8))
                //{                    
                //    string line = reader.ReadLine();
                //    int id = 1;
                //    while (line != null)
                //    {
                        
                //        string[] elements = line.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
                //        StringBuilder sqlCommand = new StringBuilder();
                //        sqlCommand.Append("INSERT INTO History (Id, Data, DailyCalories, UserName) VALUES (");
                //        sqlCommand.Append(id.ToString()+",");
                //        id++;
                //        DateTime date = DateTime.ParseExact(elements[0], "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                //        string dateString = date.ToShortDateString();
                //        sqlCommand.Append("'" + dateString + "',");
                //        sqlCommand.Append(decimal.Parse(elements[1]).ToString() + ", ");
                //        sqlCommand.Append("'Admin')");
                //        SqlCeCommand cmd = new SqlCeCommand(sqlCommand.ToString(), dbCon);
                //        cmd.ExecuteNonQuery();
                //        line = reader.ReadLine();
                //    }
                //}

                using (StreamReader reader = new StreamReader("..\\..\\Winnie the Poh.txt", Encoding.UTF8))
                {
                    string line = reader.ReadLine();
                    
                    while (line != null)
                    {
                        for (int id = 1; id <= 35; id++)
                        {
                            string[] elements = line.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
                            StringBuilder sqlCommand = new StringBuilder();
                            sqlCommand.Append("INSERT INTO DailyHistory (Id, ProductName, Quantity, Calories, HistoryId) VALUES (");
                            sqlCommand.Append(id.ToString() + ",");
                            id++;
                            DateTime date = DateTime.ParseExact(elements[0], "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            string dateString = date.ToShortDateString();
                            sqlCommand.Append("'" + dateString + "',");
                            sqlCommand.Append(decimal.Parse(elements[1]).ToString() + ", ");
                            sqlCommand.Append("'Admin')");
                            SqlCeCommand cmd = new SqlCeCommand(sqlCommand.ToString(), dbCon);
                            cmd.ExecuteNonQuery();
                        }
                        line = reader.ReadLine();
                    }
                } 

            }
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalorimeterUI());
        }
    }
}
