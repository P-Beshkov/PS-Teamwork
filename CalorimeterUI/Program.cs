namespace CalorimeterUI
{
    using Data;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;

    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //DBManager.UpdateDailyHistory();
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalorimeterUI());
        }
  }
}