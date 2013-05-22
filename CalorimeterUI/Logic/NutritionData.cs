using System;
using System.Linq;


namespace Logic
{
    public struct NutritionData : IComparable<NutritionData>
    {
        public string name;
        public int calories;
        public float? carbohydrates;
        public float? fat;
        public float? protein;
        public TypeFood type ;
        public NutritionData(string name, int calories) : this(name, calories,null,null,null)
        {
            
        }
        public NutritionData(string name, int calories, float? carbohydrates, float? fat, float? protein)
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
