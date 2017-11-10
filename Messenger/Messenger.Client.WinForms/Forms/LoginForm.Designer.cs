namespace Messenger.Client.WinForms.Forms
{
    partial class LoginForm
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
            this.LblUserId = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.txtBoxId = new System.Windows.Forms.MaskedTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSingUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblUserId
            // 
            this.LblUserId.AutoSize = true;
            this.LblUserId.Location = new System.Drawing.Point(12, 30);
            this.LblUserId.Name = "LblUserId";
            this.LblUserId.Size = new System.Drawing.Size(19, 17);
            this.LblUserId.TabIndex = 0;
            this.LblUserId.Text = "Id";
            this.LblUserId.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 80);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(57, 17);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Пароль";
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(95, 77);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(257, 22);
            this.txtBoxPassword.TabIndex = 3;
            // 
            // txtBoxId
            // 
            this.txtBoxId.Location = new System.Drawing.Point(95, 27);
            this.txtBoxId.Name = "txtBoxId";
            this.txtBoxId.Size = new System.Drawing.Size(257, 22);
            this.txtBoxId.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(277, 131);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLogin.Location = new System.Drawing.Point(196, 131);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 30);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSingUp
            // 
            this.btnSingUp.Location = new System.Drawing.Point(12, 131);
            this.btnSingUp.Name = "btnSingUp";
            this.btnSingUp.Size = new System.Drawing.Size(161, 30);
            this.btnSingUp.TabIndex = 7;
            this.btnSingUp.Text = "Зарегистрироваться";
            this.btnSingUp.UseVisualStyleBackColor = true;
            this.btnSingUp.Click += new System.EventHandler(this.btnSingUp_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnSingUp;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(382, 178);
            this.Controls.Add(this.btnSingUp);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtBoxId);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.LblUserId);
            this.Name = "LoginForm";
            this.Text = "Войдите или зарегистрируйтесь";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblUserId;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.MaskedTextBox txtBoxId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSingUp;
    }
}