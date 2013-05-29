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
                    string password = DBManager.GetPasswordByEmail(email);
                    SendForgottenPasswordToMail(password, email);
                    MessageBox.Show("Password send. Check your email within a few minutes.");
                    this.Close();
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
            string fromEmail = "Calorimeter.UI@gmail.com";
            string fromName = "Calorimeter";
            MailAddress fromAddress = new MailAddress(fromEmail, fromName);
            MailAddress toAddress = new MailAddress(userEmail, "Mr./Mrs.");

            string fromPassword = "pavelviktor";
            string subject = "Calorimeter password recover";
            string body = "Hello,\n we send you your forgotten passowrd - " + password + "\nSee you soon at Calorimeter UI.";

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
