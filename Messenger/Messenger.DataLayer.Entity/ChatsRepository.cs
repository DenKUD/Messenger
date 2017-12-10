using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DataLayer;
using Messenger.Model;
using Messenger.DataLayer.Entity.Extentions;

namespace Messenger.DataLayer.Entity
{
    public class ChatsRepository : IChatsRepository
    {
        public void AddUser(Guid chatId, Guid userId)
        {
            using (var db = new MessengerContext())
            {
                var chat = db.Chats.Find(chatId);
                chat.Users.Clear();
                db.Users.Find(userId).Chats.Add(chat);
                db.SaveChanges();
            }
        }

        public Chat Create(IEnumerable<Guid> members, string name)
        {
            List<User> chatMembers = new List<User>();
            foreach (var m in members)
                chatMembers.Add(new User { Id = m });
            List<Users> chatMembersEntityModel = new List<Users>();
            foreach (var m in chatMembers)
                chatMembersEntityModel.Add(ModelEntityConverter.Convert( new UsersRepository().Get(m.Id)));
            Chat result = new Chat
            {
                Name = name,
                Id = Guid.NewGuid(),
                Members=chatMembers
            };
            Chats entityChat =new Chats
            {
                Id=result.Id,
                Name=result.Name
            };
            using (var db = new MessengerContext())
            {
                foreach (var m in chatMembersEntityModel)
                    db.Users.Find(m.Id).Chats.Add(entityChat);
                db.SaveChanges();
            }
            return result;
        }

        public void DeleteChat(Guid chatId)
        {
            using (var db = new MessengerContext())
            {
                var chatToDelete = db.Chats.Find(chatId);
                if (chatToDelete == null) throw new ArgumentException($"Чат с id {chatId} не найден");
                db.Chats.Remove(chatToDelete);
                db.SaveChanges();
            }
        }

        public void DeleteUser(Guid chatId, Guid userId)
        {
            using (var db = new MessengerContext())
            {
                var userToDelete = db.Users.First(u => u.Id == userId);
                userToDelete.Chats.Remove(new Chats { Id = chatId });
                db.SaveChanges();
            }
        }

        public Chat Get(Guid chatId)
        {
            Chat result;
            using (var db = new MessengerContext())
            {
                var gotChats=db.Chats.Find(chatId);
                if (gotChats == null) throw new ArgumentException($"Чат с id {chatId} не найден");
                List<User> members = new List<User>();
                foreach (var u in gotChats.Users)
                    members.Add(new User { Id = u.Id });
                result = new Chat { Id = gotChats.Id, Name = gotChats.Name, Members = members };
            }
            return result;
        }

        public IEnumerable<Chat> GetUserChats(Guid userId)
        {
            List<Chat> chats = new List<Chat>();
            List<Chats> cchats = new List<Chats>();

            using (var db = new MessengerContext())
            {
                cchats.AddRange(db.Users.Find(userId).Chats);
            
            foreach (var c in cchats)
                chats.Add(ModelEntityConverter.Convert(c));
            }
            return chats;
        }
    }
}
