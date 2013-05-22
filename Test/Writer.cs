using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Writer
    {
        public static void WriteToFile(string text, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(text);
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
