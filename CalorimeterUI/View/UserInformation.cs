using Data;
using Logic;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CalorimeterUI.View
{
    public partial class UserInformation : Form
    {
        private User user;

        public string NewUsername { get; private set; }
       
        public UserInformation(User user)
        {
            InitializeComponent();
            this.user = user;
            FillData();
        }

        private void FillData()
        {
            textBoxName.Text = user.Name;
            textBoxUsername.Text = user.Nickname;
            textBoxEmail.Text = user.Email;
        }

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonUpdateInformationClick(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string newUsername = textBoxUsername.Text;
            string newPass = textBoxPassword.Text;
            string repeatedPass = textBoxRepeatPassword.Text;
            string email = textBoxEmail.Text;
            string encDecKey = "calorimeterPS";
            string oldPass = RijndaelEncryptDecrypt.Encrypt(textBoxOldPassword.Text, encDecKey);

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Enter valid name.");
                return;
            }
            if (string.IsNullOrWhiteSpace(newUsername))
            {
                MessageBox.Show("Enter valid username.");
                return;
            }
            if (repeatedPass != newPass)
            {
                MessageBox.Show("Passwords didn't match.");
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Enter valid email.");
                return;
            }
            if (oldPass != this.user.Password)
            {
                MessageBox.Show("Incorrect password.");
                return;
            }
            if (newUsername!= user.Nickname && !DBManager.IsUernameFree(newUsername))
            {
                MessageBox.Show("Username is already taken.");
                return;
            }
            if (email != user.Email && !DBManager.IsEmailFree(email))
            {
                MessageBox.Show("Email is already taken.");
                return;
            }

            if (newPass == string.Empty)
            {
                newPass = RijndaelEncryptDecrypt.Decrypt(oldPass, encDecKey);
            }

            try
            {
                DBManager.ChangeUserData(this.user.Nickname, newUsername, newPass, email, name);
                this.NewUsername = newUsername;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't update data. " + ex.Message);
            }
        }

        private bool IsValidEmail(string email)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex regex = new Regex(strRegex);
            if (regex.IsMatch(email))
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
