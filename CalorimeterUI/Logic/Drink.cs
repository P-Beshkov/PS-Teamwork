using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public abstract class Drink : Nutrition
    {
        protected Drink() : base()
        {
            this.metrics = "milliliters";
        }
    }
}
