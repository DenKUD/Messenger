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
            this.btnPost = new System.Windows.Forms.Button();
            this.flowLayoutPanelChatMembers = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelMessages = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxAttach = new System.Windows.Forms.PictureBox();
            this.timerGetMessages = new System.Windows.Forms.Timer(this.components);
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
            this.txtBoxPost.Location = new System.Drawing.Point(58, 303);
            this.txtBoxPost.Multiline = true;
            this.txtBoxPost.Name = "txtBoxPost";
            this.txtBoxPost.Size = new System.Drawing.Size(323, 57);
            this.txtBoxPost.TabIndex = 2;
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(387, 303);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(187, 57);
            this.btnPost.TabIndex = 3;
            this.btnPost.Text = "Отправить";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // flowLayoutPanelChatMembers
            // 
            this.flowLayoutPanelChatMembers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelChatMembers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelChatMembers.Location = new System.Drawing.Point(387, 20);
            this.flowLayoutPanelChatMembers.Name = "flowLayoutPanelChatMembers";
            this.flowLayoutPanelChatMembers.Size = new System.Drawing.Size(187, 277);
            this.flowLayoutPanelChatMembers.TabIndex = 4;
            // 
            // flowLayoutPanelMessages
            // 
            this.flowLayoutPanelMessages.AutoScroll = true;
            this.flowLayoutPanelMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelMessages.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMessages.Location = new System.Drawing.Point(6, 20);
            this.flowLayoutPanelMessages.Name = "flowLayoutPanelMessages";
            this.flowLayoutPanelMessages.Size = new System.Drawing.Size(375, 277);
            this.flowLayoutPanelMessages.TabIndex = 5;
            this.flowLayoutPanelMessages.WrapContents = false;
            // 
            // pictureBoxAttach
            // 
            this.pictureBoxAttach.Location = new System.Drawing.Point(6, 303);
            this.pictureBoxAttach.Name = "pictureBoxAttach";
            this.pictureBoxAttach.Size = new System.Drawing.Size(46, 57);
            this.pictureBoxAttach.TabIndex = 7;
            this.pictureBoxAttach.TabStop = false;
            // 
            // timerGetMessages
            // 
            this.timerGetMessages.Interval = 5000;
            this.timerGetMessages.Tick += new System.EventHandler(this.timerGetMessages_Tick);
            // 
            // ChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxAttach);
            this.Controls.Add(this.flowLayoutPanelMessages);
            this.Controls.Add(this.flowLayoutPanelChatMembers);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.txtBoxPost);
            this.Controls.Add(this.lblChatName);
            this.Name = "ChatControl";
            this.Size = new System.Drawing.Size(577, 363);
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
        private System.Windows.Forms.Timer timerGetMessages;
    }
}
