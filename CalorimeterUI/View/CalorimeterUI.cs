using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Logic;
using CalorimeterUI.View;

namespace CalorimeterUI
{
    public partial class CalorimeterUI : Form
    {
        private User user;

        public CalorimeterUI()
        {
            InitializeComponent();
            DisableControls();
        }

        // user isn't logged-in
        private void DisableControls()
        {
            mainGroupBox.Visible = false;
            logoutBtn.Visible = false;
            currentUserName.Text = "anonymous!";
            AddProduct.Visible = false;
            loginBtn.Visible = true;
            registerBtn.Visible = true;
        }

        // user is logged-in
        private void EnableControls()
        {
            mainGroupBox.Visible = true;
            registerBtn.Visible = false;
            loginBtn.Visible = false;
            logoutBtn.Visible = true;
            currentUserName.Text = this.user.Name + "!";
            if (this.user.Type == UserType.Admin)
            {
                AddProduct.Visible = true;
            }
        }

        private void showProductDesc_Click(object sender, EventArgs e)
        {
            productsListView.Visible = true;
        }

        private void addMeat_Click(object sender, EventArgs e)
        {
            WriteDataType(TypeFood.Meat);
            ShowMenu();
        }

        private void addFish_Click(object sender, EventArgs e)
        {
            WriteDataType(TypeFood.Fish);
            ShowMenu();
        }

        private void addFruits_Click(object sender, EventArgs e)
        {
            WriteDataType(TypeFood.Fruit);
            ShowMenu();
        }

        private void addVegetables_Click(object sender, EventArgs e)
        {
            WriteDataType(TypeFood.Vegetables);
            ShowMenu();
        }

        private void addBread_Click(object sender, EventArgs e)
        {
            WriteDataType(TypeFood.Bread);
            ShowMenu();
        }

        private void addCereals_Click(object sender, EventArgs e)
        {
            WriteDataType(TypeFood.Cereals);
            ShowMenu();
        }

        private void addNuts_Click(object sender, EventArgs e)
        {
            WriteDataType(TypeFood.Nuts);
            ShowMenu();
        }

        private void addSoftDrink_Click(object sender, EventArgs e)
        {
            WriteDataType(TypeFood.SoftDrinks);
            ShowMenu();
        }

        private void addAlocohol_Click(object sender, EventArgs e)
        {
            WriteDataType(TypeFood.Alchohol);
            ShowMenu();
        }

        private void addToList_Click(object sender, EventArgs e)
        {
            NutritionData item = new NutritionData();

            if (addProductName.Text == String.Empty)
            {
                MessageBox.Show("Wrong input! Enter product name.");
                return;
            }
            else
            {
                item.name = addProductName.Text;
            }

            if (addCalories.Text == String.Empty)
            {
                MessageBox.Show("Wrong input! Enter calories.");
                return;
            }
            else
            {
                int calories;

                if (!int.TryParse(addCalories.Text, out calories))
                {
                    MessageBox.Show("Wrong input! Enter calories in correct format.");
                    return;
                }
                else
                {
                    item.calories = calories;
                }
            }

            if (addCarbo.Text != String.Empty)
            {
                decimal carbohydrates;

                if (!decimal.TryParse(addCarbo.Text, out carbohydrates))
                {
                    MessageBox.Show("Wrong input! Enter carbohydrates in correct format.");
                    return;
                }
                else
                {
                    item.carbohydrates = carbohydrates;
                }
            }

            if (addFat.Text != String.Empty)
            {
                decimal fat;

                if (!decimal.TryParse(addFat.Text, out fat))
                {
                    MessageBox.Show("Wrong input! Enter fats in correct format.");
                    return;
                }
                else
                {
                    item.fat = fat;
                }
            }

            if (addProteins.Text != String.Empty)
            {
                decimal protein;

                if (!decimal.TryParse(addProteins.Text, out protein))
                {
                    MessageBox.Show("Wrong input! Enter proteins in correct format.");
                    return;
                }
                else
                {
                    item.protein = protein;
                }
            }
            TypeFood type = (TypeFood)Enum.Parse(typeof(TypeFood), this.type.Text);
            item.type = type;
            DBManager.AddNewFood(item);

            ApplicationLogic.AddNewNutrition(item, this.type.Text);

            HideMenu();
        }

        private void WriteDataType(TypeFood type)
        {
            this.type.Text = type.ToString();
        }

        private void ShowMenu()
        {
            this.addProductName.Visible = true;
            this.addCalories.Visible = true;
            this.addCarbo.Visible = true;
            this.addFat.Visible = true;
            this.addProteins.Visible = true;
            this.addToList.Visible = true;
            this.removeFromList.Visible = true;
            this.AddProduct.Visible = false;
            this.AddProduct.Visible = true;
            this.saveProduct.Visible = true;
        }

        private void HideMenu()
        {
            this.addProductName.Visible = false;
            this.addCalories.Visible = false;
            this.addCarbo.Visible = false;
            this.addFat.Visible = false;
            this.addProteins.Visible = false;
            this.addToList.Visible = false;
            this.removeFromList.Visible = false;

            this.addProductName.Text = String.Empty;
            this.addCalories.Text = String.Empty;
            this.addCarbo.Text = String.Empty;
            this.addFat.Text = String.Empty;
            this.addProteins.Text = String.Empty;
        }

        private void ShowEatForms()
        {
            this.enterProductWeight.Visible = true;
            this.addProductBtn.Visible = true;
            this.saveProduct.Visible = true;
        }

        private void MeatList_Click(object sender, EventArgs e)
        {
            MeatList.Items.Clear();

            foreach (var item in DBManager.LoadProducts(TypeFood.Meat))
            {
                MeatList.Items.Add(item);
            }
        }

        private void MeatList_SelectedItem(object sender, EventArgs e)
        {
            ShowEatForms();

            this.type.Text = TypeFood.Meat.ToString();
            this.Current.Text = MeatList.ComboBoxElement.Text;
        }

        private void FishList_Click(object sender, EventArgs e)
        {
            FishList.Items.Clear();

            foreach (var item in DBManager.LoadProducts(TypeFood.Fish))
            {
                FishList.Items.Add(item);
            }
        }

        private void FishList_SelectedItem(object sender, EventArgs e)
        {
            ShowEatForms();

            this.type.Text = TypeFood.Fish.ToString();
            this.Current.Text = FishList.ComboBoxElement.Text;
        }

        private void FruitsList_Click(object sender, EventArgs e)
        {
            FruitsList.Items.Clear();

            foreach (var item in DBManager.LoadProducts(TypeFood.Fruit))
            {
                FruitsList.Items.Add(item);
            }
        }

        private void FruitsList_SelectedItem(object sender, EventArgs e)
        {
            ShowEatForms();

            this.type.Text = TypeFood.Fruit.ToString();
            this.Current.Text = FruitsList.ComboBoxElement.Text;
        }

        private void VegetablesList_Click(object sender, EventArgs e)
        {
            VegetablesList.Items.Clear();

            foreach (var item in DBManager.LoadProducts(TypeFood.Vegetables))
            {
                VegetablesList.Items.Add(item);
            }
        }

        private void VegetablesList_SelectedItem(object sender, EventArgs e)
        {
            ShowEatForms();

            this.type.Text = TypeFood.Vegetables.ToString();
            this.Current.Text = VegetablesList.ComboBoxElement.Text;
        }

        private void BreadList_Click(object sender, EventArgs e)
        {
            BreadList.Items.Clear();

            foreach (var item in DBManager.LoadProducts(TypeFood.Bread))
            {
                BreadList.Items.Add(item);
            }
        }

        private void BreadList_SelectedItem(object sender, EventArgs e)
        {
            ShowEatForms();

            this.type.Text = TypeFood.Bread.ToString();
            this.Current.Text = BreadList.ComboBoxElement.Text;
        }

        private void CerealsList_Click(object sender, EventArgs e)
        {
            CerealsList.Items.Clear();

            foreach (var item in DBManager.LoadProducts(TypeFood.Cereals))
            {
                CerealsList.Items.Add(item);
            }
        }

        private void CerealsList_SelectedItem(object sender, EventArgs e)
        {
            ShowEatForms();

            this.type.Text = TypeFood.Cereals.ToString();
            this.Current.Text = CerealsList.ComboBoxElement.Text;
        }

        private void NutsList_Click(object sender, EventArgs e)
        {
            NutsList.Items.Clear();

            foreach (var item in DBManager.LoadProducts(TypeFood.Nuts))
            {
                NutsList.Items.Add(item);
            }
        }

        private void NutsList_SelectedItem(object sender, EventArgs e)
        {
            ShowEatForms();

            this.type.Text = TypeFood.Nuts.ToString();
            this.Current.Text = NutsList.ComboBoxElement.Text;
        }

        private void SoftDrinksList_Click(object sender, EventArgs e)
        {
            SoftDrinksList.Items.Clear();

            foreach (var item in DBManager.LoadProducts(TypeFood.SoftDrinks))
            {
                SoftDrinksList.Items.Add(item);
            }
        }

        private void SoftDrinksList_SelectedItem(object sender, EventArgs e)
        {
            ShowEatForms();

            this.type.Text = TypeFood.SoftDrinks.ToString();
            this.Current.Text = SoftDrinksList.ComboBoxElement.Text;
        }

        private void AlcoholList_Click(object sender, EventArgs e)
        {
            AlcoholList.Items.Clear();

            foreach (var item in DBManager.LoadProducts(TypeFood.Alchohol))
            {
                AlcoholList.Items.Add(item);
            }
        }

        private void AlcoholList_SelectedItem(object sender, EventArgs e)
        {
            ShowEatForms();

            this.type.Text = TypeFood.Alchohol.ToString();
            this.Current.Text = AlcoholList.ComboBoxElement.Text;
        }

        private void addProductBtn_Click(object sender, EventArgs e)
        {
            string input = this.enterProductWeight.Text;
            int value;

            if (!int.TryParse(input, out value))
            {
                MessageBox.Show("Wrong input! Enter weight in correct format.");
                return;
            }
            
            //ApplicationLogic.AddEatenNutrition(type.Text, Current.Text, value);
            user.AddEatenFood(DateTime.Now, Current.Text, value);
            DBManager.AddEatenFood(currentUserName, DateTime.Now, Current.Text, value);
            this.enterProductWeight.Visible = false;
            this.addProductBtn.Visible = false;
            this.enterProductWeight.Text = String.Empty;
        }

        private void saveProduct_Click(object sender, EventArgs e)
        {
            ApplicationLogic.Save();
            this.saveProduct.Visible = false;
        }

        private void currentDay_Click(object sender, EventArgs e)
        {
            this.statisticsGraph.Series.Clear();
            this.statisticsGraph.Visible = true;
            this.resetStatistics.Visible = true;

            this.statisticsGraph.ShowTitle = true;
            this.statisticsGraph.ShowLegend = true;

            this.statisticsGraph.Title = "Today";

            this.statisticsGraph.Text = this.statisticsGraph.Title;
            this.statisticsGraph.LegendTitle = "Legend";
            this.statisticsGraph.ChartElement.LegendElement.Alignment = ContentAlignment.TopCenter;

            DataSet set = new DataSet();

            DataTable eatenFood = new DataTable("Calories");

            set.Tables.Add(eatenFood);

            foreach (DataTable table in set.Tables)
            {
                table.Columns.Add("Month");
                table.Columns.Add("Usage", typeof(double));
            }

            List<Tuple<DateTime, decimal>> current = ApplicationLogic.ShowLastWeek();
            eatenFood.Rows.Add("Today", current[6].Item2);

            this.statisticsGraph.DataSource = set;
            this.statisticsGraph.BackColor = Color.Red;
            BarSeries eatenFoodVar = new BarSeries("Usage", "Month");
            this.statisticsGraph.DataMember = "Calories";
            this.statisticsGraph.LegendTitle = "Calories";
            this.statisticsGraph.Series.AddRange(eatenFoodVar);
        }

        private void pastWeek_Click(object sender, EventArgs e)
        {
            this.statisticsGraph.Series.Clear();
            this.statisticsGraph.Visible = true;
            this.resetStatistics.Visible = true;

            this.statisticsGraph.ShowTitle = true;
            this.statisticsGraph.ShowLegend = true;

            this.statisticsGraph.Title = "Today";

            this.statisticsGraph.Text = this.statisticsGraph.Title;
            this.statisticsGraph.LegendTitle = "Legend";
            this.statisticsGraph.ChartElement.LegendElement.Alignment = ContentAlignment.TopCenter;

            DataSet set = new DataSet();

            DataTable eatenFood = new DataTable("Calories");

            set.Tables.Add(eatenFood);

            foreach (DataTable table in set.Tables)
            {
                table.Columns.Add("Month");
                table.Columns.Add("Usage", typeof(double));
            }

            List<Tuple<DateTime, decimal>> current = ApplicationLogic.ShowLastWeek();
            
            for (int i = 0; i < current.Count; i++)
            {
                eatenFood.Rows.Add(String.Format("Day {0}", i + 1), current[i].Item2);
            }

            this.statisticsGraph.DataSource = set;
            this.statisticsGraph.BackColor = Color.Red;
            BarSeries eatenFoodVar = new BarSeries("Usage", "Month");
            this.statisticsGraph.DataMember = "Calories";
            this.statisticsGraph.LegendTitle = "Calories";
            this.statisticsGraph.Series.AddRange(eatenFoodVar);
        }

        private void lastMonth_Click(object sender, EventArgs e)
        {
            this.statisticsGraph.Series.Clear();
            this.statisticsGraph.Visible = true;
            this.resetStatistics.Visible = true;

            this.statisticsGraph.ShowTitle = true;
            this.statisticsGraph.ShowLegend = true;

            this.statisticsGraph.Title = "Today";

            this.statisticsGraph.Text = this.statisticsGraph.Title;
            this.statisticsGraph.LegendTitle = "Legend";
            this.statisticsGraph.ChartElement.LegendElement.Alignment = ContentAlignment.TopCenter;

            DataSet set = new DataSet();

            DataTable eatenFood = new DataTable("Calories");

            set.Tables.Add(eatenFood);

            foreach (DataTable table in set.Tables)
            {
                table.Columns.Add("Month");
                table.Columns.Add("Usage", typeof(double));
            }

            List<Tuple<DateTime, decimal>> current = ApplicationLogic.ShowLastMonth();

            for (int i = 0; i < current.Count; i++)
            {
                eatenFood.Rows.Add(i + 1, current[i].Item2);
            }

            this.statisticsGraph.DataSource = set;
            this.statisticsGraph.BackColor = Color.Red;
            BarSeries eatenFoodVar = new BarSeries("Usage", "Month");
            this.statisticsGraph.DataMember = "Calories";
            this.statisticsGraph.LegendTitle = "Calories";
            this.statisticsGraph.Series.AddRange(eatenFoodVar);
        }

        private void resetStatistics_Click(object sender, EventArgs e)
        {
            this.statisticsGraph.Series.Clear();
            this.statisticsGraph.Visible = false;
            this.resetStatistics.Visible = false;
        }

        private void removeFromList_Click(object sender, EventArgs e)
        {
            this.addProductName.Text = String.Empty;
            this.addCalories.Text = String.Empty;
            this.addCarbo.Text = String.Empty;
            this.addFat.Text = String.Empty;
            this.addProteins.Text = String.Empty;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.OK)
            {
                //TODO: Remove and replace with loginForm.User when it's rdy
                //only for test
                this.user = loginForm.User;//new User("Winnie the Pooh");
                //this.userStatus = user.userStatus;

                EnableControls();
            }
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            DisableControls();
            this.user.Type = UserType.Anonymous;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            if (registerForm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Thanks for registration. Please login with your username and password.");
            }
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void statisticsGraph_Click(object sender, EventArgs e)
        {

        }
    }
}
