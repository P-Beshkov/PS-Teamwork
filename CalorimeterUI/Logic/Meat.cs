using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Meat : Food
    {
        public Meat() : base()
        {
            this.fileLocation = "..\\..\\Data\\Meat.txt";
            this.LoadProducts();
        }
  
    }
}
