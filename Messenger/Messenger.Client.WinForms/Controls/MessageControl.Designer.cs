﻿namespace Messenger.Client.WinForms.Controls
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
            this.components = new System.ComponentModel.Container();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.txtBoxContents = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStripSaveImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.сохранитьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveattachDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStripSaveImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(3, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
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
            this.txtBoxContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxContents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxContents.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtBoxContents.Location = new System.Drawing.Point(100, 19);
            this.txtBoxContents.Multiline = true;
            this.txtBoxContents.Name = "txtBoxContents";
            this.txtBoxContents.ReadOnly = true;
            this.txtBoxContents.Size = new System.Drawing.Size(237, 94);
            this.txtBoxContents.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.contextMenuStripSaveImage;
            this.pictureBox1.ErrorImage = global::Messenger.Client.WinForms.Properties.Resources.attach;
            this.pictureBox1.Location = new System.Drawing.Point(0, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // contextMenuStripSaveImage
            // 
            this.contextMenuStripSaveImage.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripSaveImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьИзображениеToolStripMenuItem});
            this.contextMenuStripSaveImage.Name = "contextMenuStripSaveImage";
            this.contextMenuStripSaveImage.Size = new System.Drawing.Size(253, 28);
            // 
            // сохранитьИзображениеToolStripMenuItem
            // 
            this.сохранитьИзображениеToolStripMenuItem.Name = "сохранитьИзображениеToolStripMenuItem";
            this.сохранитьИзображениеToolStripMenuItem.Size = new System.Drawing.Size(252, 24);
            this.сохранитьИзображениеToolStripMenuItem.Text = "Сохранить изображение";
            this.сохранитьИзображениеToolStripMenuItem.Click += new System.EventHandler(this.сохранитьИзображениеToolStripMenuItem_Click);
            // 
            // MessageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtBoxContents);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.lblUsername);
            this.Name = "MessageControl";
            this.Size = new System.Drawing.Size(339, 120);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStripSaveImage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.TextBox txtBoxContents;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SaveFileDialog saveattachDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSaveImage;
        private System.Windows.Forms.ToolStripMenuItem сохранитьИзображениеToolStripMenuItem;
    }
}
