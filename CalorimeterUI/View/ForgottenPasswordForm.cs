using Data;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CalorimeterUI.View
{
    public partial class ForgottenPasswordForm : Form
    {
        public ForgottenPasswordForm()
        {
            InitializeComponent();
        }

        private void OnEmailTextChange(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            if (IsValidEmail(email))
            {
                labelWrongMail.Visible = false;
            }
            else
            {
                labelWrongMail.Visible = true;
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

        private void ButtonSendPassToMailClick(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            if (IsValidEmail(email))
            {
                try
                {
                    string password = "gosho";//DBManager.GetPasswordByEmail(email);
                    SendForgottenPasswordToMail(password, email);
                    MessageBox.Show("Password send. Check your email within a few minutes.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while sending email. " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter valid email.");
                return;
            }
        }

        private void SendForgottenPasswordToMail(string password, string userEmail)
        {
            MailMessage mail = new MailMessage(new MailAddress("calorimeter.ui@abv.bg"),
                new MailAddress(userEmail));
            SmtpClient smtpServer = new SmtpClient();
            smtpServer.Port = 465;
            smtpServer.Host = "smtp.abv.bg";
            smtpServer.Timeout = 10000;
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Credentials = new NetworkCredential("calorimeter.ui@abv.bg", "viktorpavel");
            smtpServer.EnableSsl = true;
            
            mail.Subject = "Password Recover.";
            mail.Body = "Hello,\n we send you your forgotten passowrd " + password + "\nSee you soon at Calorimeter UI.";

            smtpServer.Send(mail);
        }
    }
}
