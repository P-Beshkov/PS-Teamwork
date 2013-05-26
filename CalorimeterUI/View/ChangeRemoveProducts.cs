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
        private DataSet dataSet;
        private SqlCeConnection dbCon;
        private SqlCeCommandBuilder cmdBldr;
        private SqlCeDataAdapter dataAdapter;

        public ChangeRemoveProducts()
        {
            InitializeComponent();
            dataSet = new DataSet();
            // 1. Create connection.
            dbCon = new SqlCeConnection("Data Source=..\\..\\CalorimeterLocal.sdf");
            // 2. init SqlDataAdapter with select command and connection
            dataAdapter = new SqlCeDataAdapter("Select * from Products", dbCon);
            // 3. fill in insert, update, and delete commands
            cmdBldr = new SqlCeCommandBuilder(dataAdapter);
            dataAdapter.Fill(dataSet, "Products");
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
            dataAdapter.Update(dataSet, "Products");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
