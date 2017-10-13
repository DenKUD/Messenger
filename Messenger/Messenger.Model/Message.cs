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
    }
}
