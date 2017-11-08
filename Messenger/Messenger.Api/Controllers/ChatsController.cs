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
    public class ChatsController : ApiController
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IChatsRepository _ChatsRepository;
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS; Initial Catalog=Messenger;Trusted_Connection=True;";
        private Logger logger;

        public ChatsController()
        {
            _usersRepository = new UsersRepository(ConnectionString);
            _ChatsRepository = new ChatsRepository(ConnectionString, _usersRepository);
            logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Get Chat by id
        /// </summary>
        /// <param name="id">Chatid</param>
        /// <returns> chat </returns>
        [HttpGet]
        [Route("api/chats/{id}")]
        public Chat Get(Guid id)
        {
            return _ChatsRepository.Get(id);
        }

        /// <summary>
        /// Get user chat`s Ids
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/userchats/{id}")]
        public IEnumerable<Chat> GetUserChats(Guid id)
        {
            return _ChatsRepository.GetUserChats(id);
        }


        /// <summary>
        /// Creates a chat
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/chats/{name}")]
        public Chat Create([FromBody] IEnumerable<Guid> members, string name)
        {
            logger.Trace("Попытка создания чата с именем: {0}", name);
            var result = _ChatsRepository.Create(members,name);
            logger.Info("Создан чат с именем: {0} и id: {1}", result.Name, result.Id);
            return result;
        }

        /// <summary>
        /// Delete chat by id
        /// </summary>
        /// <param name="id">chat id</param>
        [HttpDelete]
        [Route("api/chats/{id}")]
        public void Delete(Guid id)
        {
            logger.Trace("Попытка удаления чата с id: {0}", id);
            _ChatsRepository.DeleteChat(id);
            logger.Info("Чат с id: {0} удален", id);
        }

        
        /// <summary>
        /// Adds new member to a chat
        /// </summary>
        /// <param name="newmember">New member id</param>
        /// <param name="id"> Chat id</param>
        [HttpPut]
        [Route("api/chats/{id}/{newMember_id}")]
        public void AddUser(Guid newmember_id,Guid id)
        {
            logger.Trace("Попытка добавления пользователя с id: {0} в чат с id: {1}", newmember_id, id);
            _ChatsRepository.AddUser(id,newmember_id);
            logger.Info("Пользовател с id: {0} добавлен в чат с id: {1}", newmember_id, id);

        }

        /// <summary>
        /// Deletes member from a Chat
        /// </summary>
        /// <param name="chat_id"> Chat id</param>
        /// <param name="user_id"> Member id</param>
        [HttpDelete]
        [Route("api/chats/{Chat_id}/{User_id}")]
        public void DeleteUser(Guid chat_id,  Guid user_id)
        {
            logger.Trace("Попытка удаления пользователя с id: {0} из чата с id: {1}", user_id, chat_id);
            _ChatsRepository.DeleteUser(chat_id, user_id);
            logger.Info("Пользователь с id: {0} удален из чата с id: {1}", user_id, chat_id);
        }

    }
}
