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
        private ServiceClient _serviceClient;
        private User _user;
        public ChatControl()
        {
            InitializeComponent();
            _chat = new Chat { };
            _user = new User { };
            _serviceClient =new ServiceClient("http://localhost:56121/api/") ;
            _messages = new List<Model.Message> { };
            
        }
        public ChatControl(Model.Chat cchat,ServiceClient serviceClient,User user)
        {
            InitializeComponent();
            _chat = cchat;
            _serviceClient = serviceClient;
            _user = user;
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
            GetMessages();
            DisplayMessages();
            timerGetMessages.Start();
        }

        public void SetServiceClient(ServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        public void SetUser(User user)
        {
            _user = user;
        }
        public void RefreshMembers()
        {
            flowLayoutPanelChatMembers.SuspendLayout();
            flowLayoutPanelChatMembers.Controls.Clear();
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
            _messages.OrderBy(x => x.dtime);
            flowLayoutPanelMessages.SuspendLayout();
            flowLayoutPanelMessages.Controls.Clear();
            foreach (Model.Message m in _messages)
                flowLayoutPanelMessages.Controls.Add(new MessageControl(m));
            flowLayoutPanelMessages.ResumeLayout();
            flowLayoutPanelMessages.Refresh();
        }

        public bool GetMessages()
        { 
            
            List<Model.Message> newMessages = new List<Model.Message> { };
            foreach (Guid id in _serviceClient.GetChatMessegesIds(_chat.Id))
                newMessages.Add(_serviceClient.GetMessage(id));
            if (!_messages.SequenceEqual(newMessages))
            {
                _messages.Clear(); _messages.AddRange(newMessages); return true;
            }
            return false;
        }

        public void DisplayMessages()
        {
            _messages.OrderBy(x => x.dtime.Ticks);
            flowLayoutPanelMessages.SuspendLayout();
            flowLayoutPanelMessages.Controls.Clear();
            foreach (Model.Message m in _messages)
                flowLayoutPanelMessages.Controls.Add(new MessageControl(m));
            flowLayoutPanelMessages.ResumeLayout();
            flowLayoutPanelMessages.Refresh();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            
            User user = new User { };
            user.Id = _user.Id;
            Chat chat = new Chat { };
            chat.Id = _chat.Id;
            var MessageToPost = new Model.Message
            { Text = txtBoxPost.Text, Chat = chat, User=user,dtime=DateTime.Now,SelfDestroy=false,IsRead=false };
            _serviceClient.CreateMessage(MessageToPost);
           
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {

        }

        private void timerGetMessages_Tick(object sender, EventArgs e)
        {
            if(GetMessages()) DisplayMessages();
        }
    }
}
