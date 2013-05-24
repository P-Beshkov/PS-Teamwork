using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace Logic
{
    public abstract class Nutrition : ILoadable, ISavable, IEnumerable<NutritionData>
    { 
        public List<NutritionData> availableProducts;
        protected string fileLocation;
        protected int loadedProducts;
        public string metrics;       

        public Nutrition()
        {
            this.fileLocation = "Not specified";
            this.loadedProducts = 0;
            this.metrics = "Not specified";
            this.availableProducts = new List<NutritionData>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<NutritionData> GetEnumerator()
        {
            foreach (var item in this.availableProducts)
            {
                yield return item;
            }
        }
        public IEnumerable GetItemsWithCaloriesLess(int calories)
        {
            IEnumerable result =
                                from token in this.availableProducts
                                where token.calories < calories
                                orderby token.calories
                                select token;
            return result;
        }
        public NutritionData SearchItem(string name)
        {
            NutritionData found = this.availableProducts.Find(
                (item) => { return item.name == name; });
            return found;
        }

        public NutritionData this[int index]
        {
            get 
            {
                return this.availableProducts[index];
            }
        }

        public void LoadProducts()
        { 
            using (StreamReader reader = new StreamReader(this.fileLocation))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] elements = line.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
                    NutritionData newProduct = new NutritionData();
                    newProduct.name = elements[0];
                    newProduct.protein = decimal.Parse(elements[1]);
                    newProduct.fat = decimal.Parse(elements[2]);
                    newProduct.carbohydrates = decimal.Parse(elements[3]);
                    newProduct.calories = int.Parse(elements[4]);
                    this.availableProducts.Add(newProduct);
                    this.loadedProducts++;
                    line = reader.ReadLine();
                }
            }
            this.availableProducts.Sort();
        }

        public void AddNewNutrution(NutritionData item)
        {
            this.availableProducts.Add(item);
        }

        public void SaveProducts()
        {
            using (StreamWriter writer = new StreamWriter(this.fileLocation, true, Encoding.UTF8))
            {
                for (int i = this.loadedProducts; i < this.availableProducts.Count; i++)
                {
                    string data = String.Format("{0}^{1}^{2}^{3}^{4}", this.availableProducts[i].name,
                        this.availableProducts[i].protein, this.availableProducts[i].fat,
                        this.availableProducts[i].carbohydrates, this.availableProducts[i].calories);
                    writer.WriteLine(data);
                    this.loadedProducts++;
                }
            }
        }

        public string GetProducts()
        {
            StringBuilder temp = new StringBuilder(32);
            for (int i = 0; i < this.availableProducts.Count; i++)
            {
                temp.AppendFormat("{0} {1} {2} {3} {4}\n", this.availableProducts[i].name, this.availableProducts[i].protein,
                    this.availableProducts[i].fat, this.availableProducts[i].carbohydrates, this.availableProducts[i].calories);
            }
            return temp.ToString();
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} items in {2}", this.GetType(), this.availableProducts.Count, this.fileLocation);
        }
    }
}