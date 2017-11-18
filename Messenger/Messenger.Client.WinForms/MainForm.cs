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
            _serviceClient = new ServiceClient("http://localhost:56121/api/");
            InitializeComponent();
            chatControl1.SetServiceClient(_serviceClient);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            Login();
           
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            using (var form = new AddContactForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (form.userToFindId != Guid.Empty) _contacts.Add(_serviceClient.GetUser(form.userToFindId));
                        else
                        {
                            if (form.userToFindName != "") _contacts.AddRange(_serviceClient.GetUserByUsername(form.userToFindName));
                            else MessageBox.Show("Ничего не введено");
                        }
                    }
                    catch (ArgumentException exep)
                    {
                        MessageBox.Show("Пользователь не найден");
                    }
                }
            };

            foreach (Model.User u in _contacts)
                lstboxContacts.Items.Add(u.Name);
            lstboxContacts.Refresh();
            List<string> contactIdsToWrite = new List<string>();
            foreach (Model.User u in _contacts)
                contactIdsToWrite.Add(u.Id.ToString());
            System.IO.File.WriteAllLines(_user.Id.ToString() + ".contacts", contactIdsToWrite);
            
        }

        private void toolStripMenuItemCreateChat_Click(object sender, EventArgs e)
        {
            string ChatName;
            using (var form = new StartChatForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ChatName = form.ChatName;
                    List<Guid> members = new List<Guid>();
                    members.Add(_user.Id);
                    members.Add(_contacts.Where(u => u.Name == lstboxContacts.SelectedItem.ToString()).Single().Id);
                    _chats.Add(_serviceClient.CreateChat(members, ChatName));
                    lstBoxChats.Items.Clear();
                    foreach (Model.Chat c in _chats)
                        lstBoxChats.Items.Add(c.Name);
                    lstBoxChats.Refresh();
                    
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _activeChat = _chats.Where(u => u.Name == lstBoxChats.SelectedItem.ToString()).Single();
            chatControl1.SetChat(_activeChat);
        }

        private void покинутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var chatId  = _chats.Where(u => u.Name == lstBoxChats.SelectedItem.ToString()).Single().Id;
            _serviceClient.DeleteUserFromChat(chatId, _user.Id);
            _chats.Clear();
            _chats.AddRange(_serviceClient.GetUserChats(_user.Id));
        }

        private void lstBoxChats_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void выходИхПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private bool Login()
        {
            using (var form = new LoginForm(_serviceClient))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _user = _serviceClient.GetUser(form.user.Id);
                    if ((_user.Id != Guid.Empty) && (form.user.Password == _user.Password))
                    {
                        smalProfileUserProfile.Update(_user);
                        chatControl1.SetUser(_user);
                        _chats.AddRange(_serviceClient.GetUserChats(_user.Id));
                        foreach (Model.Chat c in _chats)
                            lstBoxChats.Items.Add(c.Name);
                        if (System.IO.File.Exists(_user.Id.ToString() + ".contacts"))
                        {
                            var contactsIds = System.IO.File.ReadLines(_user.Id.ToString() + ".contacts");
                            foreach (string c in contactsIds)
                            {
                                try { _contacts.Add(_serviceClient.GetUser(Guid.Parse(c))); }
                                catch (FormatException) { }
                            }
                            foreach (Model.User u in _contacts)
                                lstboxContacts.Items.Add(u.Name);
                            lstboxContacts.Refresh();
                        }

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Необходимо войти или зарегистрироваться");
                    return false;
                }
            };
        }

        private void Logout()
        {
            _user = null;
            _chats.Clear();
            lstBoxChats.Items.Clear();
            _contacts.Clear();
            lstboxContacts.Items.Clear();
            chatControl1.Clear();
            smalProfileUserProfile.Clear();
        }

        private void войтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void пригласитьВАктивныйЧатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var newMemberId = _contacts.Where(u => u.Name == lstboxContacts.SelectedItem.ToString()).Single().Id;
                _serviceClient.AddUserToChat(newMemberId, _activeChat.Id);
                chatControl1.RefreshChat();
                chatControl1.RefreshMembers();
            }
            catch (NullReferenceException) { };
        }

        private void toolStripMenuDeleteUser_Click(object sender, EventArgs e)
        {
            
        }

        private void lstBoxChats_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                _activeChat = _chats.Where(u => u.Name == lstBoxChats.SelectedItem.ToString()).Single();
                chatControl1.SetChat(_activeChat);
            }
            catch (NullReferenceException) { };
        }
    }
}
