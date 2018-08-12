using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public String Name;
        public byte[] Userpic { get; set; }
        public string Bio { get; set; }
        public string Password { get; set; }

    }
}
