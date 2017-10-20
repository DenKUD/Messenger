using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Messenger.Model;
using System.Text;

namespace Messenger.DataLayer.Sql.Tests
{
    [TestClass]
    public class ChatsRepositoryTest
    {
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS; Initial Catalog=Messenger;Trusted_Connection=True;";

        private readonly List<Guid> _tempUsers = new List<Guid>();
        private readonly List<Guid> _tempChats = new List<Guid>();

        [TestMethod]
        public void ShouldStartChatWithUser()
        {
            //arrange
            var user = new User
            {
                Name = "testUser",
                Userpic = Encoding.UTF8.GetBytes("ava"),
                Password = "password",
                Bio = "test"
            };

            const string chatName = "чатик";

            //act
            var usersRepository = new UsersRepository(ConnectionString);
            var result = usersRepository.Create(user);

            _tempUsers.Add(result.Id);

            var chatRepository = new ChatsRepository(ConnectionString, usersRepository);
            var chat = chatRepository.Create(new[] { result.Id }, chatName);
            var userChats = chatRepository.GetUserChats(user.Id);

            _tempChats.Add(chat.Id);
            //asserts
            Assert.AreEqual(chatName, chat.Name);
            Assert.AreEqual(user.Id, chat.Members.Single().Id);
            Assert.AreEqual(chat.Id, userChats.ElementAt(0).Id);
            Assert.AreEqual(chat.Name, userChats.Single().Name);
        }

        [TestMethod]
        public void ShouldGetChat()
        {
            //arrange
            var user = new User
            {
                Name = "testUser",
                Userpic = Encoding.UTF8.GetBytes("ava"),
                Password = "password",
                Bio = "test"
            };

            const string chatName = "чатик";

            //act
            var usersRepository = new UsersRepository(ConnectionString);
            var result = usersRepository.Create(user);

            _tempUsers.Add(result.Id);

            var chatRepository = new ChatsRepository(ConnectionString, usersRepository);
            var chat = chatRepository.Create(new[] { result.Id }, chatName);
            var gotChat = chatRepository.Get(chat.Id);

            _tempChats.Add(chat.Id);
            //asserts
            
            Assert.AreEqual(chat.Name, gotChat.Name);
            Assert.AreEqual(chat.Id, gotChat.Id);
           
            CollectionAssert.Equals(chat.Members,gotChat.Members);
            
        }

        [TestMethod]
        public void ShouldAddUserToChat()
        {
            //arrange
            var user = new User
            {
                Name = "testUser",
                Userpic = Encoding.UTF8.GetBytes("ava"),
                Password = "password",
                Bio = "test"
            };

            var userToAdd = new User
            {
                Name = "testUser2",
                Userpic = Encoding.UTF8.GetBytes("ava2"),
                Password = "password2",
                Bio = "test2"
            };
            const string chatName = "чатик";

            //act
            var usersRepository = new UsersRepository(ConnectionString);
            var result = usersRepository.Create(user);
            var addedresult= usersRepository.Create(userToAdd);

            _tempUsers.Add(result.Id);
            _tempUsers.Add(addedresult.Id);

            var chatRepository = new ChatsRepository(ConnectionString, usersRepository);
            var chat = chatRepository.Create(new[] { result.Id }, chatName);
            chatRepository.AddUser(chat.Id, addedresult.Id);
            var userChats = chatRepository.GetUserChats(addedresult.Id);

            _tempChats.Add(chat.Id);
            //asserts

            Assert.AreEqual(chat.Id,userChats.ElementAt(0).Id);
            Assert.AreEqual(chat.Name, userChats.ElementAt(0).Name);
            

        }


        [TestCleanup]
        public void Clean()
        {
            foreach (var id in _tempUsers)
                new UsersRepository(ConnectionString).Delete(id);
            foreach (var id in _tempChats)
                new ChatsRepository(ConnectionString, new UsersRepository(ConnectionString)).DeleteChat(id);
        }
    }
}
