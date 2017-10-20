using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Messenger.DataLayer;
using Messenger.DataLayer.Sql;
using Messenger.Model;

namespace Messenger.Api.Controllers
{
    public class MessagesController : ApiController
    {
        private readonly IMessagesRepository _messagesRepository;
        private readonly IUsersRepository _UsersRepository;
        private readonly IChatsRepository _ChatsRepository;
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS; Initial Catalog=Messenger;Trusted_Connection=True;";

        public MessagesController()
        {
            _UsersRepository = new UsersRepository(ConnectionString);
            _ChatsRepository = new ChatsRepository(ConnectionString, _UsersRepository);
            _messagesRepository = new MessageRepository(ConnectionString, _UsersRepository, _ChatsRepository);
        }

        

    }
}

