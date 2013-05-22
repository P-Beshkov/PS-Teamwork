using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using CalorimeterUI.View;


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
            //SqlCeConnection dbCon = new SqlCeConnection(
            //    @"Data Source=D:\PS - Teamwork\CalorimeterUI\CalorimeterLocal.sdf");
            //dbCon.Open();
            //using (dbCon)
            //{
            //    SqlCeCommand command = new SqlCeCommand("SELECT * FROM Products", dbCon);
            //    SqlCeDataReader reader = command.ExecuteReader();
            //    using (reader)
            //    {
            //        while (reader.Read())
            //        {
            //            string category = (string)reader["Category"];
            //            string productName = (string)reader["ProductName"];
            //            float calories = (float)reader["Calories"];
            //        }
            //    }
                
            //}
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalorimeterUI());           
        }
    }
}
