using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Messenger.Model;

namespace Messenger.Client.WinForms.Controls
{
    public partial class ChatControl : UserControl
    {
        private Chat _chat;
        private List<Model.Message> _messages;
        public ChatControl()
        {
            InitializeComponent();
            _chat = new Chat { };
            _messages = new List<Model.Message> { };
            
        }
        public ChatControl(Model.Chat cchat)
        {
            InitializeComponent();
            _chat = cchat;
            RefreshMembers();        
        }
        public void AddMessage(Messenger.Model.Message message)
        {
            flowLayoutPanelMessages.Controls.Add(new MessageControl(message));
        }

        public void SetChat(Chat chat)
        {
            _chat = chat;
            RefreshMembers();
        }

        public void RefreshMembers()
        {
            flowLayoutPanelChatMembers.SuspendLayout();
            foreach (User member in _chat.Members)
            {
                flowLayoutPanelChatMembers.Controls.Add(new SmalProfile(member));
            }
            flowLayoutPanelChatMembers.ResumeLayout();
        }
        
        public void GetMessages(List<Model.Message> messages)
        {
            _messages.Clear();
            _messages.AddRange(messages);
        }
    }
}
