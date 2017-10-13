using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Model;

namespace Messenger.DataLayer
{
     public interface IMessagesRepository
    {
        Message CreateMessage(Message message);
        void DeleteMessage(Guid messageId);
        Message GetMessage(Guid messageId);
        IEnumerable<Guid> GetChatMessagesIds(Guid chatId);

    }
}
