using System;
using System.Linq;


namespace Logic
{
    public struct NutritionData : IComparable<NutritionData>
    {
        public string name;
        public decimal calories;
        public decimal carbohydrates;
        public decimal fat;
        public decimal protein;
        public TypeFood type ;
        public NutritionData(string name, decimal calories) : this(name, calories,0,0,0)
        {
            
        }
        public NutritionData(string name, decimal calories, decimal carbohydrates, decimal fat, decimal protein)
        {
            this.name = name;
            this.calories = calories;
            this.carbohydrates = carbohydrates;
            this.fat = fat;
            this.protein = protein;
            this.type = TypeFood.Meat;
        }

        public int CompareTo(NutritionData other)
        {
            return this.name.CompareTo(other.name);            
        }
    }
}
