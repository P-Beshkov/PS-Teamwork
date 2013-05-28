namespace CalorimeterUI.View
{
    partial class ForgottenPasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgottenPasswordForm));
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.buttonSendPassToEmail = new System.Windows.Forms.Button();
            this.labelWrongMail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(133, 10);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(165, 20);
            this.textBoxEmail.TabIndex = 0;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.OnEmailTextChange);
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.BackColor = System.Drawing.Color.Transparent;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelEmail.Location = new System.Drawing.Point(34, 10);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(93, 20);
            this.labelEmail.TabIndex = 1;
            this.labelEmail.Text = "Enter email:";
            // 
            // buttonSendPassToEmail
            // 
            this.buttonSendPassToEmail.BackColor = System.Drawing.Color.White;
            this.buttonSendPassToEmail.Image = ((System.Drawing.Image)(resources.GetObject("buttonSendPassToEmail.Image")));
            this.buttonSendPassToEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSendPassToEmail.Location = new System.Drawing.Point(313, 8);
            this.buttonSendPassToEmail.Name = "buttonSendPassToEmail";
            this.buttonSendPassToEmail.Size = new System.Drawing.Size(75, 50);
            this.buttonSendPassToEmail.TabIndex = 2;
            this.buttonSendPassToEmail.Text = "Send";
            this.buttonSendPassToEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSendPassToEmail.UseVisualStyleBackColor = false;
            this.buttonSendPassToEmail.Click += new System.EventHandler(this.ButtonSendPassToMailClick);
            // 
            // labelWrongMail
            // 
            this.labelWrongMail.AutoSize = true;
            this.labelWrongMail.BackColor = System.Drawing.Color.Transparent;
            this.labelWrongMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelWrongMail.ForeColor = System.Drawing.Color.Red;
            this.labelWrongMail.Location = new System.Drawing.Point(129, 38);
            this.labelWrongMail.Name = "labelWrongMail";
            this.labelWrongMail.Size = new System.Drawing.Size(169, 20);
            this.labelWrongMail.TabIndex = 3;
            this.labelWrongMail.Text = "Please enter valid mail!";
            this.labelWrongMail.Visible = false;
            // 
            // ForgottenPasswordForm
            // 
            this.AcceptButton = this.buttonSendPassToEmail;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(400, 67);
            this.Controls.Add(this.labelWrongMail);
            this.Controls.Add(this.buttonSendPassToEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxEmail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ForgottenPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ForgottenPasswordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Button buttonSendPassToEmail;
        private System.Windows.Forms.Label labelWrongMail;
    }
}