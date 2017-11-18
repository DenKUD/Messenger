namespace Messenger.Client.WinForms.Forms
{
    partial class AddContactForm
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
            this.txtBoxUserName = new System.Windows.Forms.TextBox();
            this.txtBoxId = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxUserName
            // 
            this.txtBoxUserName.Location = new System.Drawing.Point(149, 12);
            this.txtBoxUserName.Name = "txtBoxUserName";
            this.txtBoxUserName.Size = new System.Drawing.Size(158, 22);
            this.txtBoxUserName.TabIndex = 0;
            // 
            // txtBoxId
            // 
            this.txtBoxId.Location = new System.Drawing.Point(149, 40);
            this.txtBoxId.Name = "txtBoxId";
            this.txtBoxId.Size = new System.Drawing.Size(158, 22);
            this.txtBoxId.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 17);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(131, 17);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Имя пользователя";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 45);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(19, 17);
            this.lblId.TabIndex = 3;
            this.lblId.Text = "Id";
            // 
            // btnFind
            // 
            this.btnFind.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFind.Location = new System.Drawing.Point(149, 68);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(77, 32);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "Найти";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(232, 68);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddContactForm
            // 
            this.AcceptButton = this.btnFind;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(313, 107);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtBoxId);
            this.Controls.Add(this.txtBoxUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddContactForm";
            this.Text = "Найти пользователя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxUserName;
        private System.Windows.Forms.TextBox txtBoxId;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnCancel;
    }
}