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
            this.picBoxUserPic = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserPic)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxUserPic
            // 
            this.picBoxUserPic.Location = new System.Drawing.Point(3, 3);
            this.picBoxUserPic.Name = "picBoxUserPic";
            this.picBoxUserPic.Size = new System.Drawing.Size(46, 43);
            this.picBoxUserPic.TabIndex = 0;
            this.picBoxUserPic.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(55, 29);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(46, 17);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "label1";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.picBoxUserPic);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(194, 52);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxUserPic;
        private System.Windows.Forms.Label lblUsername;
    }
}
