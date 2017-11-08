using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Messenger.DataLayer;
using Messenger.DataLayer.Sql;
using Messenger.Model;
using Messenger.Api.Filters;
using NLog;
namespace Messenger.Api.Controllers
{
    [ExpectedExceptionsFilter]
    public class MessagesController : ApiController
    {
        private readonly IMessagesRepository _messagesRepository;
        private readonly IUsersRepository _UsersRepository;
        private readonly IChatsRepository _ChatsRepository;
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS; Initial Catalog=Messenger;Trusted_Connection=True;";
        private Logger logger;

        public MessagesController()
        {
            _UsersRepository = new UsersRepository(ConnectionString);
            _ChatsRepository = new ChatsRepository(ConnectionString, _UsersRepository);
            _messagesRepository = new MessageRepository(ConnectionString, _UsersRepository, _ChatsRepository);
            logger = LogManager.GetCurrentClassLogger();
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
            logger.Trace("Попытка опубликования сообщения");
            var result = _messagesRepository.CreateMessage(message);
            logger.Info("Опубликовано сообщение с id: {0} в чат с id {1}", result.Id, result.Chat.Id);
            return result;
        }

        /// <summary>
        /// Delete a message
        /// </summary>
        /// <param name="id">Message id</param>
        [HttpDelete]
        [Route("api/messages/{id}")]
        public void Delete(Guid id)
        {
            logger.Trace("Попытка удаления сообщения с id: {0}", id);
            _messagesRepository.DeleteMessage(id);
            logger.Info("Сообщение с id: {0} удалено", id);
        }

        /// <summary>
        /// Changes message content(text, attach, isread)
        /// </summary>
        /// <param name="id">message id</param>
        /// <param name="message">New message</param>
        /// <returns>Updated message</returns>
        [HttpPut]
        [Route("api/messages/{id}")]
        public Message Update(Guid id, [FromBody] Message message)
        {
            logger.Trace("Попытка изменения сообщени с id: {0}", id);
            var result = _messagesRepository.Update(id, message);
            logger.Info("Сообщение с id: {0} изменено", result.Id);
            return result;
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

