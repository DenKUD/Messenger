namespace Messenger.Client.WinForms.Forms
{
    partial class ProfileInfo
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
            this.lblUsername = new System.Windows.Forms.Label();
            this.picBoxUserPic = new System.Windows.Forms.PictureBox();
            this.txtBoxUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.lblBio = new System.Windows.Forms.Label();
            this.txtBoxBio = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLoadUserpic = new System.Windows.Forms.Button();
            this.openFileDialogUserPic = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserPic)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(202, 25);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(131, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Имя пользователя";
            // 
            // picBoxUserPic
            // 
            this.picBoxUserPic.Location = new System.Drawing.Point(12, 25);
            this.picBoxUserPic.Name = "picBoxUserPic";
            this.picBoxUserPic.Size = new System.Drawing.Size(184, 165);
            this.picBoxUserPic.TabIndex = 1;
            this.picBoxUserPic.TabStop = false;
            // 
            // txtBoxUsername
            // 
            this.txtBoxUsername.Location = new System.Drawing.Point(339, 25);
            this.txtBoxUsername.Name = "txtBoxUsername";
            this.txtBoxUsername.Size = new System.Drawing.Size(203, 22);
            this.txtBoxUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(202, 56);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(57, 17);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Пароль";
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(339, 56);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(203, 22);
            this.txtBoxPassword.TabIndex = 4;
            // 
            // lblBio
            // 
            this.lblBio.AutoSize = true;
            this.lblBio.Location = new System.Drawing.Point(202, 91);
            this.lblBio.Name = "lblBio";
            this.lblBio.Size = new System.Drawing.Size(111, 17);
            this.lblBio.TabIndex = 5;
            this.lblBio.Text = "Немного о себе";
            // 
            // txtBoxBio
            // 
            this.txtBoxBio.Location = new System.Drawing.Point(339, 91);
            this.txtBoxBio.Multiline = true;
            this.txtBoxBio.Name = "txtBoxBio";
            this.txtBoxBio.Size = new System.Drawing.Size(203, 99);
            this.txtBoxBio.TabIndex = 6;
            this.txtBoxBio.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(339, 196);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 45);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Принять";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(458, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 45);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnLoadUserpic
            // 
            this.btnLoadUserpic.Location = new System.Drawing.Point(12, 196);
            this.btnLoadUserpic.Name = "btnLoadUserpic";
            this.btnLoadUserpic.Size = new System.Drawing.Size(103, 45);
            this.btnLoadUserpic.TabIndex = 9;
            this.btnLoadUserpic.Text = "Загрузить изображение";
            this.btnLoadUserpic.UseVisualStyleBackColor = true;
            this.btnLoadUserpic.Click += new System.EventHandler(this.btnLoadUserpic_Click);
            // 
            // openFileDialogUserPic
            // 
            this.openFileDialogUserPic.FileName = "openFileDialog1";
            this.openFileDialogUserPic.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogUserPic_FileOk);
            // 
            // ProfileInfo
            // 
            this.AcceptButton = this.btnOk;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(554, 253);
            this.Controls.Add(this.btnLoadUserpic);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtBoxBio);
            this.Controls.Add(this.lblBio);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtBoxUsername);
            this.Controls.Add(this.picBoxUserPic);
            this.Controls.Add(this.lblUsername);
            this.Name = "ProfileInfo";
            this.Text = "PrpofileInfo";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.PrpofileInfo_DragDrop);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.PictureBox picBoxUserPic;
        private System.Windows.Forms.TextBox txtBoxUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.Label lblBio;
        private System.Windows.Forms.TextBox txtBoxBio;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLoadUserpic;
        private System.Windows.Forms.OpenFileDialog openFileDialogUserPic;
    }
}