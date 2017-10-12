using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Messenger.Model;
using System.Text;

namespace Messenger.DataLayer.Sql.Tests
{
    [TestClass]
    public class UserRepositoryTest
    {
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

        private readonly List<Guid> _tempUsers = new List<Guid>();

        [TestMethod]
        public void shouldCreateUser()
        {
            // arrange

            var user = new User
            {
                Name = "testUser",
                Userpic = Encoding.UTF8.GetBytes("ava"),
                Password = "password",
                Bio = "test"
            };

            //act
            var repository = new UsersRepository(ConnectionString);
            var result = repository.Create(user);

            _tempUsers.Add(result.Id);

            //asserts
            Assert.AreEqual(user.Name, result.Name);
            Assert.AreEqual(user.Userpic, result.Userpic);
            Assert.AreEqual(user.Password, result.Password);
            Assert.AreEqual(user.Bio, result.Bio);
        }

        [TestMethod]
        public void ShouldStartChatWithUser()
        {
            //arrange
            var user = new User
            {
                Name = "testUser",
                Userpic = Encoding.UTF8.GetBytes("ava"),
                Password = "password",
                Bio ="test"
            };

            const string chatName = "чатик";

            //act
            var usersRepository = new UsersRepository(ConnectionString);
            var result = usersRepository.Create(user);

            _tempUsers.Add(result.Id);

            var chatRepository = new ChatsRepository(ConnectionString, usersRepository);
            var chat = chatRepository.Create(new[] { user.Id }, chatName);
            var userChats = chatRepository.GetUserChats(user.Id);
            //asserts
            Assert.AreEqual(chatName, chat.Name);
            Assert.AreEqual(user.Id, chat.Members.Single().Id);
            Assert.AreEqual(chat.Id, userChats.Single().Id);
            Assert.AreEqual(chat.Name, userChats.Single().Name);
        }

        [TestCleanup]
        public void Clean()
        {
            foreach (var id in _tempUsers)
                new UsersRepository(ConnectionString).Delete(id);
        }
    }
    
}
