using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Messenger.Model;
using Messenger.DataLayer.Sql;
namespace Messenger.Api.Extentions
{
    static public class Authenticator
    {
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS; Initial Catalog=Messenger;Trusted_Connection=True;";
        static public bool Authentificate(Guid user_id,string password)
        {
            User user = new UsersRepository(ConnectionString).Get(user_id);
            return (user.Password == password);
        }
    }
}