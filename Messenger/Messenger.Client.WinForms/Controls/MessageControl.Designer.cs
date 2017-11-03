namespace Messenger.Client.WinForms.Controls
{
    partial class MessageControl
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
            this.lblDateTime = new System.Windows.Forms.Label();
            this.txtBoxContents = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveattachDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveAttach = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(3, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(46, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "label1";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new System.Drawing.Point(97, 0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(62, 17);
            this.lblDateTime.TabIndex = 1;
            this.lblDateTime.Text = "datatime";
            // 
            // txtBoxContents
            // 
            this.txtBoxContents.Location = new System.Drawing.Point(100, 20);
            this.txtBoxContents.Multiline = true;
            this.txtBoxContents.Name = "txtBoxContents";
            this.txtBoxContents.Size = new System.Drawing.Size(128, 132);
            this.txtBoxContents.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 80);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnSaveAttach
            // 
            this.btnSaveAttach.Location = new System.Drawing.Point(3, 106);
            this.btnSaveAttach.Name = "btnSaveAttach";
            this.btnSaveAttach.Size = new System.Drawing.Size(90, 26);
            this.btnSaveAttach.TabIndex = 4;
            this.btnSaveAttach.Text = "Сохранить";
            this.btnSaveAttach.UseVisualStyleBackColor = true;
            // 
            // MessageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.btnSaveAttach);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtBoxContents);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.lblUsername);
            this.Name = "MessageControl";
            this.Size = new System.Drawing.Size(235, 160);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.TextBox txtBoxContents;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SaveFileDialog saveattachDialog1;
        private System.Windows.Forms.Button btnSaveAttach;
    }
}
