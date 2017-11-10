using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Model;

namespace Messenger.Client.WinForms.Classes
{
    class MessengerInstance
    {
        public Messenger.Model.User user { get; set;}
        private readonly ServiceClient _serviceClient;
        public List<User> contacts;
        public List<Chat> chats;
        public Model.Chat activeChat;

        public MessengerInstance(ServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
            contacts = new List<Messenger.Model.User>();
            chats = new List<Messenger.Model.Chat>();
            activeChat = new Model.Chat { };
        }

        public User SetUser(Guid userId)
        {
            var result = _serviceClient.GetUser(userId);
            return result;
        }

        public void RefreshUserChats()
        {
            chats.Clear();
            chats.AddRange(_serviceClient.GetUserChats(user.Id));
        }

        public void SetActiveChat(Guid chatId)
        {
            activeChat=chats.Where(c => c.Id == chatId).Single();
        }

    }
}
