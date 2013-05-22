using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public abstract class Food : Nutrition
    {
        protected Food() : base()
        {
            this.metrics = "gram";
        }

    }
}
