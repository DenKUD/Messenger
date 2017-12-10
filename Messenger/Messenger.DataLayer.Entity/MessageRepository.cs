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
    public class MessageRepository : IMessagesRepository
    {
        public Message CreateMessage(Message message)
        {
            message.Id= Guid.NewGuid();
            var messageToPost = ModelEntityConverter.Convert(message);
            var attachId = Guid.NewGuid();
            messageToPost.Attach_id = attachId;
            messageToPost.Attaches.Id = attachId;
            using (var db = new MessengerContext())
            {
                db.Chats.Find(message.Chat.Id)
                    .Messages
                    .Add(messageToPost);
                db.SaveChanges();
            }
            return message;
        }

        public void DeleteMessage(Guid messageId)
        {
            using (var db = new MessengerContext())
            {
                var messageToDelete = db.Messages.Find(messageId);
                db.Messages.Remove(messageToDelete);
            }
        }

        public IEnumerable<Guid> GetChatMessagesIds(Guid chatId)
        {
            List<Guid> result=new List<Guid>();
            using (var db = new MessengerContext())
            {
                var gotChat = db.Chats.Find(chatId);
                foreach (var m in gotChat.Messages)
                    result.Add(m.Id);
            }
            return result;
        }

        public Message GetMessage(Guid messageId)
        {
            Message result;
            using (var db = new MessengerContext())
            {
                var gotMessage = db.Messages.Find(messageId);
                result = (ModelEntityConverter.Convert(gotMessage));
            }
            return result;
        }

        public Message Update(Guid messageId, Message newMessage)
        {
            Message result;
            using (var db = new MessengerContext())
            {
                var messageToUpdate = db.Messages.Find(messageId);
                messageToUpdate.Text = newMessage.Text;
                messageToUpdate.isRead = newMessage.IsRead;
                messageToUpdate.Attaches.Content = newMessage.Body;
                result = ModelEntityConverter.Convert(messageToUpdate);
                db.SaveChanges();
            }
            return result;
        }
    }
}
