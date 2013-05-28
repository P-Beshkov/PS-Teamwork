namespace CalorimeterUI.View
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.labelRegister = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.labelRepeatPassord = new System.Windows.Forms.Label();
            this.textBoxRepeatPassword = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelRepeatEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxRepeatEmail = new System.Windows.Forms.TextBox();
            this.notValidImage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelRegister
            // 
            this.labelRegister.AutoSize = true;
            this.labelRegister.BackColor = System.Drawing.Color.Transparent;
            this.labelRegister.Font = new System.Drawing.Font("Monotype Corsiva", 45F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelRegister.Location = new System.Drawing.Point(30, 9);
            this.labelRegister.Name = "labelRegister";
            this.labelRegister.Size = new System.Drawing.Size(400, 72);
            this.labelRegister.TabIndex = 0;
            this.labelRegister.Text = "R E G I S T E R";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelUsername.Location = new System.Drawing.Point(108, 130);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(87, 20);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "Username:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelPassword.Location = new System.Drawing.Point(113, 160);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(82, 20);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(200, 130);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(130, 20);
            this.textBoxUsername.TabIndex = 2;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(200, 160);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '•';
            this.textBoxPassword.Size = new System.Drawing.Size(130, 20);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.Location = new System.Drawing.Point(220, 300);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 50);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonRegister.Image = ((System.Drawing.Image)(resources.GetObject("buttonRegister.Image")));
            this.buttonRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRegister.Location = new System.Drawing.Point(80, 300);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(110, 50);
            this.buttonRegister.TabIndex = 7;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.ButtonRegisterClick);
            // 
            // labelRepeatPassord
            // 
            this.labelRepeatPassord.AutoSize = true;
            this.labelRepeatPassord.BackColor = System.Drawing.Color.Transparent;
            this.labelRepeatPassord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelRepeatPassord.Location = new System.Drawing.Point(57, 190);
            this.labelRepeatPassord.Name = "labelRepeatPassord";
            this.labelRepeatPassord.Size = new System.Drawing.Size(138, 20);
            this.labelRepeatPassord.TabIndex = 7;
            this.labelRepeatPassord.Text = "Repeat password:";
            // 
            // textBoxRepeatPassword
            // 
            this.textBoxRepeatPassword.Location = new System.Drawing.Point(200, 190);
            this.textBoxRepeatPassword.Name = "textBoxRepeatPassword";
            this.textBoxRepeatPassword.PasswordChar = '•';
            this.textBoxRepeatPassword.Size = new System.Drawing.Size(130, 20);
            this.textBoxRepeatPassword.TabIndex = 4;
            this.textBoxRepeatPassword.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(200, 100);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(130, 20);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelName.Location = new System.Drawing.Point(135, 100);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(55, 20);
            this.labelName.TabIndex = 10;
            this.labelName.Text = "Name:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.BackColor = System.Drawing.Color.Transparent;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelEmail.Location = new System.Drawing.Point(143, 220);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(52, 20);
            this.labelEmail.TabIndex = 11;
            this.labelEmail.Text = "Email:";
            // 
            // labelRepeatEmail
            // 
            this.labelRepeatEmail.AutoSize = true;
            this.labelRepeatEmail.BackColor = System.Drawing.Color.Transparent;
            this.labelRepeatEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelRepeatEmail.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelRepeatEmail.Location = new System.Drawing.Point(88, 250);
            this.labelRepeatEmail.Name = "labelRepeatEmail";
            this.labelRepeatEmail.Size = new System.Drawing.Size(107, 20);
            this.labelRepeatEmail.TabIndex = 12;
            this.labelRepeatEmail.Text = "Repeat email:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(200, 220);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(130, 20);
            this.textBoxEmail.TabIndex = 5;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // textBoxRepeatEmail
            // 
            this.textBoxRepeatEmail.Location = new System.Drawing.Point(200, 250);
            this.textBoxRepeatEmail.Name = "textBoxRepeatEmail";
            this.textBoxRepeatEmail.Size = new System.Drawing.Size(130, 20);
            this.textBoxRepeatEmail.TabIndex = 6;
            this.textBoxRepeatEmail.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // notValidImage
            // 
            this.notValidImage.BackColor = System.Drawing.Color.Transparent;
            this.notValidImage.Image = ((System.Drawing.Image)(resources.GetObject("notValidImage.Image")));
            this.notValidImage.Location = new System.Drawing.Point(411, 354);
            this.notValidImage.Name = "notValidImage";
            this.notValidImage.Size = new System.Drawing.Size(32, 28);
            this.notValidImage.TabIndex = 13;
            this.notValidImage.Visible = false;
            // 
            // RegisterForm
            // 
            this.AcceptButton = this.buttonRegister;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(455, 391);
            this.Controls.Add(this.notValidImage);
            this.Controls.Add(this.textBoxRepeatEmail);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelRepeatEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxRepeatPassword);
            this.Controls.Add(this.labelRepeatPassord);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelRegister);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRegister;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Label labelRepeatPassord;
        private System.Windows.Forms.TextBox textBoxRepeatPassword;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelRepeatEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxRepeatEmail;
        private System.Windows.Forms.Label notValidImage;
    }
}