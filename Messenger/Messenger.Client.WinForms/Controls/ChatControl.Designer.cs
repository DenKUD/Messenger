namespace Messenger.Client.WinForms.Controls
{
    partial class ChatControl
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
            this.lblChatName = new System.Windows.Forms.Label();
            this.txtBoxPost = new System.Windows.Forms.TextBox();
            this.contexMenuStripAttach = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.прикрепитьВложениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сделатьСамоудаляющимсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPost = new System.Windows.Forms.Button();
            this.flowLayoutPanelChatMembers = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelMessages = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxAttach = new System.Windows.Forms.PictureBox();
            this.timerRefreshMessages = new System.Windows.Forms.Timer(this.components);
            this.openFileDialogSelectAttach = new System.Windows.Forms.OpenFileDialog();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chckBoxSelsfDestroy = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contexMenuStripAttach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAttach)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChatName
            // 
            this.lblChatName.AutoSize = true;
            this.lblChatName.Location = new System.Drawing.Point(3, 0);
            this.lblChatName.Name = "lblChatName";
            this.lblChatName.Size = new System.Drawing.Size(72, 17);
            this.lblChatName.TabIndex = 0;
            this.lblChatName.Text = "chatName";
            // 
            // txtBoxPost
            // 
            this.txtBoxPost.AcceptsReturn = true;
            this.txtBoxPost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxPost.ContextMenuStrip = this.contexMenuStripAttach;
            this.txtBoxPost.Location = new System.Drawing.Point(76, 303);
            this.txtBoxPost.Multiline = true;
            this.txtBoxPost.Name = "txtBoxPost";
            this.txtBoxPost.Size = new System.Drawing.Size(305, 57);
            this.txtBoxPost.TabIndex = 2;
            this.txtBoxPost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxPost_KeyPress);
            // 
            // contexMenuStripAttach
            // 
            this.contexMenuStripAttach.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contexMenuStripAttach.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прикрепитьВложениеToolStripMenuItem,
            this.сделатьСамоудаляющимсяToolStripMenuItem});
            this.contexMenuStripAttach.Name = "contexMenuStripAttach";
            this.contexMenuStripAttach.Size = new System.Drawing.Size(271, 52);
            // 
            // прикрепитьВложениеToolStripMenuItem
            // 
            this.прикрепитьВложениеToolStripMenuItem.Name = "прикрепитьВложениеToolStripMenuItem";
            this.прикрепитьВложениеToolStripMenuItem.Size = new System.Drawing.Size(270, 24);
            this.прикрепитьВложениеToolStripMenuItem.Text = "Прикрепить вложение";
            this.прикрепитьВложениеToolStripMenuItem.Click += new System.EventHandler(this.прикрепитьВложениеToolStripMenuItem_Click);
            // 
            // сделатьСамоудаляющимсяToolStripMenuItem
            // 
            this.сделатьСамоудаляющимсяToolStripMenuItem.Name = "сделатьСамоудаляющимсяToolStripMenuItem";
            this.сделатьСамоудаляющимсяToolStripMenuItem.Size = new System.Drawing.Size(270, 24);
            this.сделатьСамоудаляющимсяToolStripMenuItem.Text = "Сделать самоудаляющимся";
            this.сделатьСамоудаляющимсяToolStripMenuItem.Click += new System.EventHandler(this.сделатьСамоудаляющимсяToolStripMenuItem_Click);
            // 
            // btnPost
            // 
            this.btnPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPost.Location = new System.Drawing.Point(387, 303);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(264, 57);
            this.btnPost.TabIndex = 3;
            this.btnPost.Text = "Отправить";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // flowLayoutPanelChatMembers
            // 
            this.flowLayoutPanelChatMembers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelChatMembers.AutoScroll = true;
            this.flowLayoutPanelChatMembers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelChatMembers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelChatMembers.Location = new System.Drawing.Point(387, 20);
            this.flowLayoutPanelChatMembers.Name = "flowLayoutPanelChatMembers";
            this.flowLayoutPanelChatMembers.Size = new System.Drawing.Size(264, 277);
            this.flowLayoutPanelChatMembers.TabIndex = 4;
            // 
            // flowLayoutPanelMessages
            // 
            this.flowLayoutPanelMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelMessages.AutoScroll = true;
            this.flowLayoutPanelMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelMessages.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMessages.Location = new System.Drawing.Point(6, 49);
            this.flowLayoutPanelMessages.Name = "flowLayoutPanelMessages";
            this.flowLayoutPanelMessages.Size = new System.Drawing.Size(375, 221);
            this.flowLayoutPanelMessages.TabIndex = 5;
            this.flowLayoutPanelMessages.WrapContents = false;
            this.flowLayoutPanelMessages.SizeChanged += new System.EventHandler(this.flowLayoutPanelMessages_SizeChanged);
            // 
            // pictureBoxAttach
            // 
            this.pictureBoxAttach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxAttach.ErrorImage = global::Messenger.Client.WinForms.Properties.Resources.attach;
            this.pictureBoxAttach.Image = global::Messenger.Client.WinForms.Properties.Resources.attach;
            this.pictureBoxAttach.Location = new System.Drawing.Point(6, 303);
            this.pictureBoxAttach.Name = "pictureBoxAttach";
            this.pictureBoxAttach.Size = new System.Drawing.Size(64, 57);
            this.pictureBoxAttach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAttach.TabIndex = 7;
            this.pictureBoxAttach.TabStop = false;
            this.pictureBoxAttach.Click += new System.EventHandler(this.pictureBoxAttach_Click);
            // 
            // timerRefreshMessages
            // 
            this.timerRefreshMessages.Interval = 4000;
            this.timerRefreshMessages.Tick += new System.EventHandler(this.timerGetMessages_Tick);
            // 
            // openFileDialogSelectAttach
            // 
            this.openFileDialogSelectAttach.FileName = "openFileDialog1";
            this.openFileDialogSelectAttach.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogSelectAttach_FileOk);
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Location = new System.Drawing.Point(6, 20);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(277, 22);
            this.txtBoxSearch.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(289, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chckBoxSelsfDestroy
            // 
            this.chckBoxSelsfDestroy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chckBoxSelsfDestroy.AutoSize = true;
            this.chckBoxSelsfDestroy.Location = new System.Drawing.Point(6, 276);
            this.chckBoxSelsfDestroy.Name = "chckBoxSelsfDestroy";
            this.chckBoxSelsfDestroy.Size = new System.Drawing.Size(213, 21);
            this.chckBoxSelsfDestroy.TabIndex = 11;
            this.chckBoxSelsfDestroy.Text = "Сделать самоудаляющимся";
            this.chckBoxSelsfDestroy.UseVisualStyleBackColor = true;
            this.chckBoxSelsfDestroy.CheckedChanged += new System.EventHandler(this.chckBoxSelsfDestroy_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chckBoxSelsfDestroy);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.pictureBoxAttach);
            this.Controls.Add(this.flowLayoutPanelMessages);
            this.Controls.Add(this.flowLayoutPanelChatMembers);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.txtBoxPost);
            this.Controls.Add(this.lblChatName);
            this.Name = "ChatControl";
            this.Size = new System.Drawing.Size(658, 363);
            this.contexMenuStripAttach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAttach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChatName;
        private System.Windows.Forms.TextBox txtBoxPost;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelChatMembers;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMessages;
        private System.Windows.Forms.PictureBox pictureBoxAttach;
        private System.Windows.Forms.Timer timerRefreshMessages;
        private System.Windows.Forms.ContextMenuStrip contexMenuStripAttach;
        private System.Windows.Forms.ToolStripMenuItem прикрепитьВложениеToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogSelectAttach;
        private System.Windows.Forms.ToolStripMenuItem сделатьСамоудаляющимсяToolStripMenuItem;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chckBoxSelsfDestroy;
        private System.Windows.Forms.Timer timer1;
    }
}
