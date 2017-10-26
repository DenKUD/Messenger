using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Messenger.DataLayer;
using Messenger.DataLayer.Sql;
using Messenger.Model;
using NLog;
using Messenger.Api.Filters;

namespace Messenger.Api.Controllers
{
    [ExpectedExceptionsFilter]
    public class UsersController : ApiController
    {
        private Logger logger;
        private readonly IUsersRepository _usersRepository;
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS; Initial Catalog=Messenger;Trusted_Connection=True;";

        public UsersController()
        {
            _usersRepository = new UsersRepository(ConnectionString);
            logger= LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        [HttpGet]
        
        [Route("api/users/{id}")]
        public User Get(Guid id)
        {
            logger.Trace("Попытка получения user");
            var result= _usersRepository.Get(id);
            logger.Trace("Попытка получения user успешна");
            return result;
        }

        /// <summary>
        /// Gets User id by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet]
        [ExpectedExceptionsFilter]
        [Route("api/users/username/{username}")]
        public IEnumerable<Guid> GetUserIdByName(string username)
        {
            logger.Trace("Попытка получения user_id по username");
            var result= _usersRepository.FindUserIdByName(username);
            logger.Trace("Попытка получения user_id по username успешна");
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/users")]
        public User Create([FromBody] User user)
        {
            User result;
            var logger = LogManager.GetCurrentClassLogger();
            logger.Info("Создание пользователя");
            result= _usersRepository.Create(user);
            logger.Info("Создание пользователя завершено id ={0}",result.Id);
            return result;

        }

        /// <summary>
        /// Delete User by id
        /// </summary>
        /// <param name="id">User id</param>
        [HttpDelete]
        [Route("api/users/{id}")]
        public void Delete(Guid id)
        {
            logger.Info("удаление пользователя c id={0}",id);
            _usersRepository.Delete(id);
            logger.Info("пользователь c id={0} удален", id);
        }

        /// <summary>
        /// Updates user info (username, bio, password, userpic)
        /// </summary>
        /// <param name="id"> User id</param>
        /// <param name="user"> New user info</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/users/{id}")]
        public User Update(Guid id,[FromBody] User user)
        {
            logger.Info("изменение данных пользователя c id={0}", id);
            var result = _usersRepository.Update(id,user);
            logger.Info("данныt пользователя c id={0} изменены", id);
            return result;
        }

    }
}
