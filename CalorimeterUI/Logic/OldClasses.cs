namespace Logic
{
    using System;

    public class Alchohol : Drink
    {
        public Alchohol() : base()
        {
            this.fileLocation = "..\\..\\Data\\Alchohol.txt";
            this.LoadProducts();
        }
    }

    public class Bread : Food
    {
        public Bread()
            : base()
        {
            this.fileLocation = "..\\..\\Data\\Bread.txt";
            this.LoadProducts();
        }
    }

    public class Cereals : Food
    {
        public Cereals()
            : base()
        {
            this.fileLocation = "..\\..\\Data\\Cereals.txt";
            this.LoadProducts();
        }
    }

    public abstract class Drink : Nutrition
    {
        protected Drink()
            : base()
        {
            this.metrics = "milliliters";
        }
    }

    public class Fish : Food
    {
        public Fish()
            : base()
        {
            this.fileLocation = "..\\..\\Data\\Fish.txt";
            this.LoadProducts();
        }
    }

    public abstract class Food : Nutrition
    {
        protected Food()
            : base()
        {
            this.metrics = "gram";
        }

    }

    public class Fruits : Food
    {
        public Fruits()
            : base()
        {
            this.fileLocation = "..\\..\\Data\\Fruits.txt";
            this.LoadProducts();
        }
    }

    public class Meat : Food
    {
        public Meat()
            : base()
        {
            this.fileLocation = "..\\..\\Data\\Meat.txt";
            this.LoadProducts();
        }
    }

    public class Nuts : Food
    {
        public Nuts()
            : base()
        {
            this.fileLocation = "..\\..\\Data\\Nuts.txt";
            this.LoadProducts();
        }
    }

    public class SoftDrinks : Drink
    {
        public SoftDrinks()
            : base()
        {
            this.fileLocation = "..\\..\\Data\\SoftDrinks.txt";
            this.LoadProducts();
        }
    }

    public class Vegetables : Food
    {
        public Vegetables()
            : base()
        {
            this.fileLocation = "..\\..\\Data\\Vegetables.txt";
            this.LoadProducts();
        }
    }
}