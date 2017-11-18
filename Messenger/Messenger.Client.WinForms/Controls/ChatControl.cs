using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Messenger.Model;
using Messenger.Client.WinForms.Forms;

namespace Messenger.Client.WinForms.Controls
{
    public partial class ChatControl : UserControl
    {
        private Chat _chat;
        private List<Model.Message> _messages;
        private ServiceClient _serviceClient;
        private User _user;
        //private System.Threading.Timer _timer;
        private byte[] _attach;
        private bool _selfDestroy;
        //private bool _gotNewMessages;
        //private int _howManyMessages;

        public ChatControl()
        {
            InitializeComponent();
            _chat = new Chat { };
            _user = new User { };
            _serviceClient =new ServiceClient("http://localhost:56121/api/") ;
            _messages = new List<Model.Message> { };
            _attach = null;
            //_gotNewMessages = false;
            //_howManyMessages = 0;
            _selfDestroy = false;
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
            timerRefreshMessages.Start();
            Enabled = true;
            //_timer = new System.Threading.Timer(new System.Threading.TimerCallback(GetMessages), null, 10, 10);
            lblChatName.Text = _chat.Name;
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

        public bool GetMessages()
        {
            List<Model.Message> newMessages = new List<Model.Message> { };
            foreach (Guid id in _serviceClient.GetChatMessegesIds(_chat.Id))
                newMessages.Add(_serviceClient.GetMessage(id));
            if (_messages.Count()!=newMessages.Count)
            {
                _messages.Clear(); _messages.AddRange(newMessages); return true;
            }
            //_gotNewMessages = true;
            else return false;
            
        }

        public void DisplayMessages()
        {
            _messages.Sort((x, y) => DateTime.Compare(x.dtime, y.dtime));
            flowLayoutPanelMessages.SuspendLayout();
            flowLayoutPanelMessages.Controls.Clear();
            foreach (Model.Message m in _messages)
            {
                m.User=_chat.Members.FirstOrDefault(member=>member.Id==m.User.Id);
                flowLayoutPanelMessages.Controls.Add(new MessageControl(m));
            }
            flowLayoutPanelMessages.VerticalScroll.Value = flowLayoutPanelMessages.VerticalScroll.Maximum;
            flowLayoutPanelMessages.ResumeLayout();
            //flowLayoutPanelMessages.Refresh();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            
            User user = new User { };
            user.Id = _user.Id;
            Chat chat = new Chat { };
            chat.Id = _chat.Id;
            var MessageToPost = new Model.Message
            { Text = txtBoxPost.Text, Chat = chat, User=user,dtime=DateTime.Now,SelfDestroy=_selfDestroy,IsRead=false,Body=_attach };
            _serviceClient.CreateMessage(MessageToPost);
            txtBoxPost.Text = "";
            _attach = null;
            pictureBoxAttach.Image = null;
            lblSelfDestroy.Text = "";
        }

        private void timerGetMessages_Tick(object sender, EventArgs e)
        {
            if (GetMessages()) {
                DisplayMessages();
            }
        }

        public void Clear()
        {
            //_timer.Dispose();
            timerRefreshMessages.Stop();
            _chat = null;
            _messages.Clear();
            _user=null;
            lblChatName.Text = "";
            flowLayoutPanelChatMembers.Controls.Clear();
            flowLayoutPanelMessages.Controls.Clear();
            Enabled = false;   
        }

        public void RefreshChat()
        {
            _chat = _serviceClient.GetChat(_chat.Id);
        }

        private void прикрепитьВложениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogSelectAttach.ShowDialog();
        }

        private void openFileDialogSelectAttach_FileOk(object sender, CancelEventArgs e)
        {
            _attach = System.IO.File.ReadAllBytes(openFileDialogSelectAttach.FileName);
            try
            {
                pictureBoxAttach.Image = (Bitmap)new ImageConverter().ConvertFrom(_attach);
            }
            catch (ArgumentException ane)
            {
                pictureBoxAttach.Image = Properties.Resources.attach as Bitmap;
            }
        }

        private void сделатьСамоудаляющимсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _selfDestroy = true;
            lblSelfDestroy.Text = "Сообщение самоудалится после получения";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text != "")
            {
                string textToSearch = txtBoxSearch.Text;
                List<Model.Message> foundMessages = new List<Model.Message> { };
                foreach (Model.Message m in _messages)
                {
                    if (m.Text.Contains(textToSearch)) foundMessages.Add(m);
                }
                using (var form = new FindMessageForm(foundMessages)) form.ShowDialog();
            }
            else MessageBox.Show("Ничего не введено");
        }
    }
}
