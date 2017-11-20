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
        private byte[] _attach;
        private bool _selfDestroy;

        public ChatControl()
        {
            InitializeComponent();
            _chat = new Chat { };
            _user = new User { };
            _serviceClient =new ServiceClient("http://localhost:56121/api/") ;
            _messages = new List<Model.Message> { };
            _attach = null;
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
            newMessages.Sort((x, y) => DateTime.Compare(x.dtime, y.dtime));
            if (!_messages.SequenceEqual(newMessages))
            {
                _messages.Clear(); _messages.AddRange(newMessages); return true;
            }
            else return false;  
        }

        public void DisplayMessages()
        {
            flowLayoutPanelMessages.SuspendLayout();
            flowLayoutPanelMessages.Controls.Clear();
            Control currentControl;
            for (int i = 0; i < _messages.Count-1 ; i++)
            {
                _messages[i].User = _chat.Members.FirstOrDefault(member => member.Id == _messages[i].User.Id);
                if ((_messages[i].SelfDestroy == true) && (_messages[i].User.Id != _user.Id))
                    _serviceClient.DeleteMessage(_messages[i].Id);
                currentControl = new MessageControl(_messages[i]);
                currentControl.Anchor= ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                flowLayoutPanelMessages.Controls.Add(currentControl);
            }
            _messages.LastOrDefault().User = _chat.Members.FirstOrDefault(member => member.Id == _messages.LastOrDefault().User.Id);
            currentControl = new MessageControl(_messages.Last());
            currentControl.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            flowLayoutPanelMessages.Controls.Add(currentControl);
            flowLayoutPanelMessages.ResumeLayout();
            flowLayoutPanelMessages.ScrollControlIntoView(currentControl);
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
            _selfDestroy = false;
            pictureBoxAttach.Image = Properties.Resources.attach as Bitmap;
            radioButtonSelfDestroy.Checked = false;
        }

        private void timerGetMessages_Tick(object sender, EventArgs e)
        {
            if (GetMessages()) {
                DisplayMessages();
            }
        }

        public void Clear()
        {
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
            try
            {
                _chat = _serviceClient.GetChat(_chat.Id);
            }
            catch (NullReferenceException) { MessageBox.Show("Нет активного чата"); }
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
            radioButtonSelfDestroy.Checked = true;
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

        private void pictureBoxAttach_Click(object sender, EventArgs e)
        {
            openFileDialogSelectAttach.ShowDialog();
        }

        private void radioButtonSelfDestroy_CheckedChanged(object sender, EventArgs e)
        {
            _selfDestroy = radioButtonSelfDestroy.Checked;
        }

        private void txtBoxPost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Return) btnPost.PerformClick();
        }
    }
}
