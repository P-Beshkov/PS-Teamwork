using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Fruits : Food
    {
        public Fruits() : base()
        {
            this.fileLocation = "..\\..\\Data\\Fruits.txt";
            this.LoadProducts();
        }
    }
}
