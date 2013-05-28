namespace CalorimeterUI.View
{
    using Data;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class ChangeRemoveProducts : Form
    {
        private DataSet dataSet = new DataSet();
        public ChangeRemoveProducts()
        {
            InitializeComponent();

            DBManager.GetProductsData(dataSet, "Products");
            dataGridView1.DataSource = dataSet;
            dataGridView1.DataMember = "Products";
        }

        private void ChangeRemoveProducts_Load(object sender, EventArgs e)
        {
            this.productsTableAdapter.Fill(this.localDataSetForPorducts.Products);
        }

        private void BtnSaveGridDataClick(object sender, EventArgs e)
        {
            try
            {
                DBManager.UpdateAdapter(dataSet, "Products");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving in database. " + ex.Message);
            }
        }

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
