namespace Messenger.Client.WinForms.Controls
{
    partial class Chat
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
            this.lblChatName = new System.Windows.Forms.Label();
            this.txtBoxPost = new System.Windows.Forms.TextBox();
            this.btnPost = new System.Windows.Forms.Button();
            this.flowLayoutPanelChatMembers = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelMessages = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblChatName
            // 
            this.lblChatName.AutoSize = true;
            this.lblChatName.Location = new System.Drawing.Point(25, 19);
            this.lblChatName.Name = "lblChatName";
            this.lblChatName.Size = new System.Drawing.Size(72, 17);
            this.lblChatName.TabIndex = 0;
            this.lblChatName.Text = "chatName";
            // 
            // txtBoxPost
            // 
            this.txtBoxPost.AcceptsReturn = true;
            this.txtBoxPost.Location = new System.Drawing.Point(28, 303);
            this.txtBoxPost.Multiline = true;
            this.txtBoxPost.Name = "txtBoxPost";
            this.txtBoxPost.Size = new System.Drawing.Size(228, 57);
            this.txtBoxPost.TabIndex = 2;
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(281, 303);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(98, 57);
            this.btnPost.TabIndex = 3;
            this.btnPost.Text = "Отправить";
            this.btnPost.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelChatMembers
            // 
            this.flowLayoutPanelChatMembers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelChatMembers.Location = new System.Drawing.Point(281, 39);
            this.flowLayoutPanelChatMembers.Name = "flowLayoutPanelChatMembers";
            this.flowLayoutPanelChatMembers.Size = new System.Drawing.Size(98, 258);
            this.flowLayoutPanelChatMembers.TabIndex = 4;
            this.flowLayoutPanelChatMembers.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelChatMembers_Paint);
            // 
            // flowLayoutPanelMessages
            // 
            this.flowLayoutPanelMessages.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMessages.Location = new System.Drawing.Point(28, 39);
            this.flowLayoutPanelMessages.Name = "flowLayoutPanelMessages";
            this.flowLayoutPanelMessages.Size = new System.Drawing.Size(228, 258);
            this.flowLayoutPanelMessages.TabIndex = 5;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelMessages);
            this.Controls.Add(this.flowLayoutPanelChatMembers);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.txtBoxPost);
            this.Controls.Add(this.lblChatName);
            this.Name = "Chat";
            this.Size = new System.Drawing.Size(416, 363);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChatName;
        private System.Windows.Forms.TextBox txtBoxPost;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelChatMembers;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMessages;
    }
}
