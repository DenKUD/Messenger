﻿namespace Messenger.Client.WinForms
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lstBoxChats = new System.Windows.Forms.ListBox();
            this.contextMenuStripChats = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.покинутьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstboxContacts = new System.Windows.Forms.ListBox();
            this.contextMenuStripContacts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCreateChat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.lblContacts = new System.Windows.Forms.Label();
            this.smalProfileUserProfile = new Messenger.Client.WinForms.Controls.SmalProfile();
            this.chatControl1 = new Messenger.Client.WinForms.Controls.ChatControl();
            this.contextMenuStripChats.SuspendLayout();
            this.contextMenuStripContacts.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstBoxChats
            // 
            this.lstBoxChats.ContextMenuStrip = this.contextMenuStripChats;
            this.lstBoxChats.FormattingEnabled = true;
            this.lstBoxChats.ItemHeight = 16;
            this.lstBoxChats.Location = new System.Drawing.Point(527, 80);
            this.lstBoxChats.Name = "lstBoxChats";
            this.lstBoxChats.Size = new System.Drawing.Size(87, 132);
            this.lstBoxChats.TabIndex = 2;
            // 
            // contextMenuStripChats
            // 
            this.contextMenuStripChats.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripChats.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.покинутьToolStripMenuItem});
            this.contextMenuStripChats.Name = "contextMenuStripChats";
            this.contextMenuStripChats.Size = new System.Drawing.Size(145, 52);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // покинутьToolStripMenuItem
            // 
            this.покинутьToolStripMenuItem.Name = "покинутьToolStripMenuItem";
            this.покинутьToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
            this.покинутьToolStripMenuItem.Text = "Покинуть";
            this.покинутьToolStripMenuItem.Click += new System.EventHandler(this.покинутьToolStripMenuItem_Click);
            // 
            // lstboxContacts
            // 
            this.lstboxContacts.ContextMenuStrip = this.contextMenuStripContacts;
            this.lstboxContacts.FormattingEnabled = true;
            this.lstboxContacts.ItemHeight = 16;
            this.lstboxContacts.Location = new System.Drawing.Point(15, 80);
            this.lstboxContacts.Name = "lstboxContacts";
            this.lstboxContacts.Size = new System.Drawing.Size(87, 132);
            this.lstboxContacts.TabIndex = 3;
            // 
            // contextMenuStripContacts
            // 
            this.contextMenuStripContacts.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripContacts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCreateChat,
            this.toolStripMenuDeleteUser});
            this.contextMenuStripContacts.Name = "contextMenuStripContacts";
            this.contextMenuStripContacts.Size = new System.Drawing.Size(154, 52);
            // 
            // toolStripMenuItemCreateChat
            // 
            this.toolStripMenuItemCreateChat.Name = "toolStripMenuItemCreateChat";
            this.toolStripMenuItemCreateChat.Size = new System.Drawing.Size(153, 24);
            this.toolStripMenuItemCreateChat.Text = "Начать чат";
            this.toolStripMenuItemCreateChat.Click += new System.EventHandler(this.toolStripMenuItemCreateChat_Click);
            // 
            // toolStripMenuDeleteUser
            // 
            this.toolStripMenuDeleteUser.CheckOnClick = true;
            this.toolStripMenuDeleteUser.Name = "toolStripMenuDeleteUser";
            this.toolStripMenuDeleteUser.Size = new System.Drawing.Size(153, 24);
            this.toolStripMenuDeleteUser.Text = "Удалить";
            // 
            // btnAddContact
            // 
            this.btnAddContact.Location = new System.Drawing.Point(15, 218);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(87, 66);
            this.btnAddContact.TabIndex = 4;
            this.btnAddContact.Text = "Добавить в контакты";
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // lblContacts
            // 
            this.lblContacts.AutoSize = true;
            this.lblContacts.Location = new System.Drawing.Point(12, 60);
            this.lblContacts.Name = "lblContacts";
            this.lblContacts.Size = new System.Drawing.Size(72, 17);
            this.lblContacts.TabIndex = 5;
            this.lblContacts.Text = "Контакты";
            // 
            // smalProfileUserProfile
            // 
            this.smalProfileUserProfile.userName = null;
            this.smalProfileUserProfile.userPic = null;
            this.smalProfileUserProfile.Location = new System.Drawing.Point(103, 12);
            this.smalProfileUserProfile.Name = "smalProfileUserProfile";
            this.smalProfileUserProfile.Size = new System.Drawing.Size(194, 52);
            this.smalProfileUserProfile.TabIndex = 1;
            // 
            // chatControl1
            // 
            this.chatControl1.Location = new System.Drawing.Point(105, 60);
            this.chatControl1.Name = "chatControl1";
            this.chatControl1.Size = new System.Drawing.Size(416, 378);
            this.chatControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 460);
            this.Controls.Add(this.lblContacts);
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.lstboxContacts);
            this.Controls.Add(this.lstBoxChats);
            this.Controls.Add(this.smalProfileUserProfile);
            this.Controls.Add(this.chatControl1);
            this.Name = "MainForm";
            this.Text = "Messenger";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStripChats.ResumeLayout(false);
            this.contextMenuStripContacts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ChatControl chatControl1;
        private Controls.SmalProfile smalProfileUserProfile;
        private System.Windows.Forms.ListBox lstBoxChats;
        private System.Windows.Forms.ListBox lstboxContacts;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Label lblContacts;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripContacts;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCreateChat;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDeleteUser;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripChats;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem покинутьToolStripMenuItem;
    }
}

