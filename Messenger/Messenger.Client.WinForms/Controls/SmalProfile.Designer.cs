namespace Messenger.Client.WinForms.Controls
{
    partial class SmalProfile
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.picBoxUserPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserPic)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(55, 29);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 17);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(55, 3);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(19, 17);
            this.lblUserId.TabIndex = 2;
            this.lblUserId.Text = "Id";
            // 
            // picBoxUserPic
            // 
            this.picBoxUserPic.Location = new System.Drawing.Point(3, 3);
            this.picBoxUserPic.Name = "picBoxUserPic";
            this.picBoxUserPic.Size = new System.Drawing.Size(46, 43);
            this.picBoxUserPic.TabIndex = 0;
            this.picBoxUserPic.TabStop = false;
            // 
            // SmalProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.picBoxUserPic);
            this.Name = "SmalProfile";
            this.Size = new System.Drawing.Size(257, 52);
            this.Click += new System.EventHandler(this.SmalProfile_Click);
            this.DoubleClick += new System.EventHandler(this.SmalProfile_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.PictureBox picBoxUserPic;
    }
}
