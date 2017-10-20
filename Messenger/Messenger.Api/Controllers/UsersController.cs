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
    public class UsersController : ApiController
    {
        private readonly IUsersRepository _usersRepository;
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS; Initial Catalog=Messenger;Trusted_Connection=True;";

        public UsersController()
        {
            _usersRepository = new UsersRepository(ConnectionString);
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
            return _usersRepository.Get(id);
        }

        /// <summary>
        /// Gets User id by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/users/username/{username}")]
        public IEnumerable<Guid> GetUserIdByName(string username)
        {
            return _usersRepository.FindUserIdByName(username);
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
            return _usersRepository.Create(user);
        }

        /// <summary>
        /// Delete User by id
        /// </summary>
        /// <param name="id">User id</param>
        [HttpDelete]
        [Route("api/users/{id}")]
        public void Delete(Guid id)
        {
            _usersRepository.Delete(id);
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
            return _usersRepository.Update(id,user);
        }

    }
}
