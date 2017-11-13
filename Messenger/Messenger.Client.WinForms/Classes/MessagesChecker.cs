using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Model;
using System.Threading;

namespace Messenger.Client.WinForms.Classes
{
    class MessagesChecker
    {
        private readonly ServiceClient _client;
        private List<Message> _messages;
        private Timer _timer;
        private Guid _chatId;
        public  MessagesChecker(ServiceClient serviceClient,IEnumerable<Message> oldMessages,Guid chatId)
        {
            _messages = new List<Message>(oldMessages);
            _client = serviceClient;
            _chatId = chatId;
        }
        
        
    }
}
