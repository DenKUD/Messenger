using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Messenger.Client.WinForms.Forms;

namespace Messenger.Client.WinForms
{
    public partial class MainForm : Form
    {
        private Messenger.Model.User _user;
        private ServiceClient _serviceClient;
        private List<Messenger.Model.User> _contacts;
        private List<Messenger.Model.Chat> _chats;
        private Model.Chat _activeChat; 
        public MainForm()
        {
            _contacts = new List<Messenger.Model.User> ();
            _chats = new List<Messenger.Model.Chat>();
            _activeChat = new Model.Chat { };
            InitializeComponent();
           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _serviceClient = new ServiceClient("http://localhost:56121/api/");
            using (var form = new LoginForm(_serviceClient))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _user = _serviceClient.GetUser(form.user.Id);
                }
            };
            smalProfileUserProfile.Update(_user);
            _chats.AddRange(_serviceClient.GetUserChats(_user.Id));
            foreach(Model.Chat c in _chats)
                lstBoxChats.Items.Add(c.Name);
            lstboxContacts.Refresh();



        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            using (var form = new AddContactForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (form.userToFindId != null) _contacts.Add(_serviceClient.GetUser(form.userToFindId));
                        else if (form.userToFindName != null) _contacts.AddRange(_serviceClient.GetUserByUsername(form.userToFindName));
                        else MessageBox.Show("Ничего не введено");
                    }
                    catch (ArgumentException exep)
                    {
                        MessageBox.Show(exep.ToString());
                    }
                }
            };

            foreach (Model.User u in _contacts)
                lstboxContacts.Items.Add(u.Name);
            lstboxContacts.Refresh();
           
        }

        private void toolStripMenuItemCreateChat_Click(object sender, EventArgs e)
        {
            List<Guid> members = new List<Guid>();
            members.Add(_user.Id);
            members.Add(_contacts.Where(u => u.Name == lstboxContacts.SelectedItem.ToString()).Single().Id );
           _chats.Add( _serviceClient.CreateChat(members, "Chatik"));
            foreach (Model.Chat c in _chats)
                lstBoxChats.Items.Add(c.Name);
            lstBoxChats.Refresh();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _activeChat = _chats.Where(u => u.Name == lstBoxChats.SelectedItem.ToString()).Single();
            chatControl1.SetChat(_activeChat);
            //chatControl1.RefreshMembers();
        }

        private void покинутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var chatId  = _chats.Where(u => u.Name == lstBoxChats.SelectedItem.ToString()).Single().Id;
            _serviceClient.DeleteUserFromChat(chatId, _user.Id);
            _chats.Clear();
            _chats.AddRange(_serviceClient.GetUserChats(_user.Id));
        }

        
    }
}
