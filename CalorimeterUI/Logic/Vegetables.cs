using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Vegetables : Food
    {
        public Vegetables() : base()
        {
            this.fileLocation = "..\\..\\Data\\Vegetables.txt";
            this.LoadProducts();
        }
    }
}
