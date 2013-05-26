using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalorimeterUI.View
{
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

        //Here is your save/update button code.
        private void btnSaveGridData_Click(object sender, EventArgs e)
        {
            DBManager.UpdateAdapter(dataSet, "Products");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
