namespace CalorimeterUI.View
{
    using Data;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class ChangeRemoveUserInformation : Form
    {
        private DataSet dataSet = new DataSet();

        public ChangeRemoveUserInformation()
        {
            InitializeComponent();

            DBManager.GetProductsData(dataSet, "Users");
            dataGridView.DataSource = dataSet;
            dataGridView.DataMember = "Users";
        }

        private void ChangeRemoveProducts_Load(object sender, EventArgs e)
        {
            this.usersTableAdapter.Fill(this.dataSetForUsers.Users);
        }

        private void ButtonSaveGridDataClick(object sender, EventArgs e)
        {
            try
            {
                DBManager.UpdateAdapter(dataSet, "Users");
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

        private void ChangeRemoveUserInformation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'calorimeterLocalDataSet1.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.dataSetForUsers.Users);

        }
    }
}
