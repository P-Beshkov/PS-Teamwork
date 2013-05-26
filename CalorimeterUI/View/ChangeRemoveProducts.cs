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

            DBManager.GetProductsData(dataSet);
            dataGridView1.DataSource = dataSet;
            dataGridView1.DataMember = "Products";
        }

        private void ChangeRemoveProducts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'calorimeterLocalDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.calorimeterLocalDataSet.Products);
        }

        private void BtnSaveGridDataClick(object sender, EventArgs e)
        {
            DBManager.UpdateAdapter(dataSet, "Products");
        }

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
