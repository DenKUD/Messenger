using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Model;

namespace Messenger.DataLayer.Entity.Extentions
{
    public static class ModelEntityConverter
    {
       public static User Convert(Users u)
        {
            var result = new User
            {
                Id = u.Id,
                Bio =u.Bio,
                Name = u.Username,
                Userpic =u.User_pic,
                Password = u.Password
            };
            return result;
        }

        public static Users Convert(User u)
        {
            var result = new Users
            {
                Id = u.Id,
                Bio = u.Bio,
                Username = u.Name,
                User_pic = u.Userpic,
                Password = u.Password
            };
            return result;
        }

        public static Chat Convert(Chats c)
        {
            List<User> members = new List<User>();
            try
            {
                foreach (var m in c.Users)
                members.Add(Convert(m));
            }
            catch (NullReferenceException) { };
            var result = new Chat
            {
                Id = c.Id,
                Name = c.Name,
                Members = members,
            };
            return result;
        }

        public static Chats Convert(Chat c)
        {
            List<Users> users = new List<Users>();
            try
            {
                foreach (var m in c.Members)
                    users.Add(Convert(m));
            }
            catch (NullReferenceException) { };
            var result = new Chats
            {
                Id = c.Id,
                Name = c.Name,
                Users=users
            };
            return result;
        }

        public static Message Convert(Messages m)
        {
            var result = new Message
            {
                Id = m.Id,
                Text = m.Text,
                dtime = (DateTime)m.Datetime,
                Body = m.Attaches.Content,
                Chat = new Chat {Id= (Guid) m.Chat_id },
                User = new User { Id =(Guid) m.User_id },
                IsRead= (bool) m.isRead,
                SelfDestroy =(bool)m.SelfDestructable
            };
            return result;
        }

        public static Messages Convert(Message m)
        {
            var result = new Messages
            {
                Id = m.Id,
                Text = m.Text,
                Datetime = m.dtime,
                Attaches = new Attaches { Content = m.Body },
                Chat_id = m.Chat.Id,
                User_id = m.User.Id,
                //Chats = new Chats { Id = m.Chat.Id },
                //Users = new Users { Id = m.User.Id },
                isRead = m.IsRead,
                SelfDestructable = m.SelfDestroy
            };
            return result;
        }
    }
}
