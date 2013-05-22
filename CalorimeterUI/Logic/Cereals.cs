using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Cereals : Food
    {
        public Cereals() : base()
        {
            this.fileLocation = "..\\..\\Data\\Cereals.txt";
            this.LoadProducts();
        }
    }
}
