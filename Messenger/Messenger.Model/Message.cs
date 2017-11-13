using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Model
{
    public class Message
    {
        public Guid Id { set; get; }
        public User User { set; get; }
        public Chat Chat { set; get; }
        public string Text { set; get; }
        public DateTime dtime { set; get; }
        public byte[] Body { get; set; }
        public bool SelfDestroy { get; set; }
        public bool IsRead { get; set; }
        public override bool Equals(Object obj)
        {
            Message messageObj = obj as Message;
            if (messageObj == null)
                return false;
            else
                return (Id.Equals(messageObj.Id)&&Text.Equals(messageObj.Text)&&Body.Equals(messageObj.Body));
        }
    }
}
