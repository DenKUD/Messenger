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

        /// <summary>
        /// gets message from repository
        /// </summary>
        /// <param name="id">message id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/messages/{id}")]
        public Message Get(Guid id)
        {
            return _messagesRepository.GetMessage(id);
        }

        /// <summary>
        /// Puts message into repository
        /// </summary>
        /// <param name="message">Message</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/messages")]
        public Message Create([FromBody] Message message)
        {
            return _messagesRepository.CreateMessage(message);
        }

        /// <summary>
        /// Delete a message
        /// </summary>
        /// <param name="id">Message id</param>
        [HttpDelete]
        [Route("api/messages/{id}")]
        public void Delete(Guid id)
        {
            _messagesRepository.DeleteMessage(id);
        }

        /// <summary>
        /// Changes message content(text, attach, isread)
        /// </summary>
        /// <param name="id">message id</param>
        /// <param name="message">New message</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/messages/{id}")]
        public Message Update(Guid id, [FromBody] Message message)
        {
            return _messagesRepository.Update(id, message);
        }

        /// <summary>
        /// Gets chat message ids
        /// </summary>
        /// <param name="chat_id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/messages/chat/{chat_id}")]
        public IEnumerable<Guid> GetChatMessageIds(Guid chat_id)
        {
            return _messagesRepository.GetChatMessagesIds(chat_id);
        }

    }
}

