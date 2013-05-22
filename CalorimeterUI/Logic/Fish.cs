using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Fish : Food
    {
        public Fish() : base()
        {
            this.fileLocation = "..\\..\\Data\\Fish.txt";
            this.LoadProducts();
        }
    }
}
