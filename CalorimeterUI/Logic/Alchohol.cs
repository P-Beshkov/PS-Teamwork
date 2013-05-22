using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Alchohol : Drink
    {
        public Alchohol() : base()
        {
            this.fileLocation = "..\\..\\Data\\Alchohol.txt";
            this.LoadProducts();
        }
    }

    
}