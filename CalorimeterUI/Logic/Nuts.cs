using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Nuts : Food
    {
        public Nuts() : base()
        {
            this.fileLocation = "..\\..\\Data\\Nuts.txt";
            this.LoadProducts();
        }
    }
}
