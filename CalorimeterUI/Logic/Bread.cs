using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Bread : Food
    {
        public Bread() : base()
        {
            this.fileLocation = "..\\..\\Data\\Bread.txt";
            this.LoadProducts();
        }
    }
}