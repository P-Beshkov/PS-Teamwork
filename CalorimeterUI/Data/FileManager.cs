namespace Data
{
    using System;
    using System.Collections.Generic;    
    using System.IO;
    using System.Text;

    public static class FileManager
    {
        public static void SaveUserData(string username, List<Tuple<DateTime, decimal>> data,
            string fileName = null, bool overwrite = false)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = username + ".txt";
            }
            //else
            //{
            //    //fileName += ".txt";
            //    bool isValidName = fileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;
            //    if (!isValidName)
            //    {
            //        throw new ArgumentException(String.Format("File name - '{0}' has invalid chars", fileName));
            //    }
            //    bool isFileNameFree = !File.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileName));
            //    if (!isFileNameFree)
            //    {
            //        throw new IOException(String.Format("'{0}' already exists", fileName));
            //    }
            //}

            using (StreamWriter writer = new StreamWriter(fileName, overwrite, Encoding.UTF8))
            {
                writer.WriteLine("UserName - {0}\n", username);
                foreach (var item in data)
                {
                    DateTime date = item.Item1;
                    string dateTimeString = String.Format("{0}.{1}.{2} ã.", date.Day, date.Month, date.Year);
                    writer.WriteLine(dateTimeString + " - " + item.Item2 + " calories.");
                }
            }
        }

        //public static List<Tuple<DateTime,decimal>> LoadUserData(string username)
        //{
        //    List<Tuple<DateTime, decimal>> result = new List<Tuple<DateTime, decimal>>();
        //    string fileName = username +".txt";

        //    bool isFileNameFree = !File.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileName));
        //    if (!isFileNameFree)
        //    {
        //        throw new IOException(String.Format("History for {0} doesn't exists", username));
        //    }
        //    using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
        //    {
        //        string line = reader.ReadLine();
        //        while (line != null)
        //        {
        //            string[] elements = line.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
        //            string dateFormat = "d.M.yyyy ã.";
        //            DateTime date = DateTime.ParseExact(elements[0], dateFormat, CultureInfo.InvariantCulture);
        //            decimal calories = decimal.Parse(elements[1]);
        //            result.Add(new Tuple<DateTime, decimal>(date, calories));
        //            line = reader.ReadLine();
        //        }
        //    }

        //    return result;
        //}
    }
}