namespace CalorimeterUI.View
{
    using Data;
    using System;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void ButtonRegisterClick(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string repeatedPassword = textBoxRepeatPassword.Text;
            string email = textBoxEmail.Text;
            string repeatedEmail = textBoxRepeatEmail.Text;

            if (IsEmptyInput(name))
            {
                MessageBox.Show("Enter valid name.");
                return;
            }

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

            if (password != repeatedPassword)
            {
                MessageBox.Show("Passwords don't match.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Enter valid email.");
                return;
            }

            if (email != repeatedEmail)
            {
                MessageBox.Show("Emails don't match.");
                return;
            }

            if (DBManager.IsUernameFree(username))
            {
                DBManager.RegisterUser(username, password, email, name);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Username is not available. Please enter another one.");
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

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            TextBox currTB = sender as TextBox;
            switch (currTB.Name)
            {
                case "textBoxName":
                case "textBoxUsername":
                case "textBoxPassword":
                    if (IsEmptyInput(currTB.Text)) MarkAsInvalid(currTB);
                    else MarkAsValid(currTB);
                    break;
                case "textBoxRepeatPassword":
                    if (currTB.Text == textBoxPassword.Text) MarkAsValid(currTB);
                    else MarkAsInvalid(currTB);
                    break;
                case "textBoxEmail":
                    if (IsValidEmail(currTB.Text)) MarkAsValid(currTB);
                    else MarkAsInvalid(currTB);
                    break;
                case "textBoxRepeatEmail":
                    if (currTB.Text == textBoxEmail.Text) MarkAsValid(currTB);
                    else MarkAsInvalid(currTB);
                    break;
                default: break;
            }
        }

        private void MarkAsValid(TextBox textbox)
        {
            textbox.ForeColor = Color.Black;
            notValidImage.Visible = false;
        }

        private void MarkAsInvalid(TextBox textbox)
        {
            textbox.ForeColor = Color.Red;
            var location = textbox.Location;
            location.X += textbox.Size.Width + 3;
            location.Y -= 3;
            notValidImage.Location = location;
            notValidImage.Visible = true;
        }
    }
}
