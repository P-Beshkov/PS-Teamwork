using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalorimeterUI.View
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (IsEmptyInput(username))
            {
                MessageBox.Show("Enter valid username.");
                return;
            }

            if (IsEmptyInput(password))
            {
                MessageBox.Show("Enter valid password.");
                return;
            }

            if(DBManager.IsUernameFree(username))
            {
                DBManager.RegisterUser(username, password);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Username is not available. Please enter another one.");
            }
        }

        private bool IsEmptyInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
