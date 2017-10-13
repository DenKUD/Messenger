using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Model;

namespace Messenger.DataLayer
{
    public interface IChatsRepository
    {
        Chat Create(IEnumerable<Guid> members, string name);
        Chat Get(Guid chatId);
        IEnumerable<Chat> GetUserChats(Guid userId);
        void DeleteChat(Guid chatId);

    }
}
