﻿using Data;
using Logic;
using System;
using System.Windows.Forms;

namespace CalorimeterUI.View
{
    public partial class LoginForm : Form
    {
        public User User { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            this.User = null;
        }

        private void ButtonLoginClick(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (IsEmptyInput(username))
            {
                MessageBox.Show("Enter valid username.");
                return;
            }
            else if (IsEmptyInput(password))
            {
                MessageBox.Show("Enter valid password.");
                return;
            }
            User usr = null;
            if (DBManager.IsUsernameValid(username,password))
            {
                //TODO: LoadUserData must load username, password, name, email, history, status
                //var loadedData = DBManager.LoadUserData(username,out status);
                //usr = new User(username, password, name, email, loadedData, status);  
                usr = DBManager.LoadUserData(username);
                this.DialogResult = DialogResult.OK;
                this.User = usr;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username/password.");
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

        private void labelForgottenPassword_Click(object sender, EventArgs e)
        {
            ForgottenPasswordForm form = new ForgottenPasswordForm();
            form.ShowDialog();
        }
    }
}
