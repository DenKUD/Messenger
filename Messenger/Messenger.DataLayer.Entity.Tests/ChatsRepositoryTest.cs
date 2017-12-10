using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Messenger.Model;

namespace Messenger.DataLayer.Entity.Tests
{
    /// <summary>
    /// Сводное описание для ChatsRepositoryTest
    /// </summary>
    [TestClass]
    public class ChatsRepositoryTest
    {
        private readonly List<Guid> _tempUsers = new List<Guid>();
        private readonly List<Guid> _tempChats = new List<Guid>();

        [TestMethod]
        public void ShouldStartChatWithUserEntity()
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
            var usersRepository = new UsersRepository();
            var result = usersRepository.Create(user);

            _tempUsers.Add(result.Id);

            var chatRepository = new ChatsRepository();
            var chat = chatRepository.Create(new[] { result.Id }, chatName);
            var userChats = chatRepository.GetUserChats(result.Id);

            _tempChats.Add(chat.Id);
            //asserts
            Assert.AreEqual(chatName, chat.Name);
            Assert.AreEqual(result.Id, chat.Members.Single().Id);
            Assert.AreEqual(chat.Id, userChats.ElementAt(0).Id);
            Assert.AreEqual(chat.Name, userChats.Single().Name);
        }

        [TestMethod]
        public void ShouldGetChatEntity()
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
            var usersRepository = new UsersRepository();
            var result = usersRepository.Create(user);

            _tempUsers.Add(result.Id);

            var chatRepository = new ChatsRepository( );
            var chat = chatRepository.Create(new[] { result.Id }, chatName);
            var gotChat = chatRepository.Get(chat.Id);

            _tempChats.Add(chat.Id);
            //asserts

            Assert.AreEqual(chat.Name, gotChat.Name);
            Assert.AreEqual(chat.Id, gotChat.Id);
            CollectionAssert.Equals(chat.Members, gotChat.Members);
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
            var usersRepository = new UsersRepository();
            var result = usersRepository.Create(user);
            var addedresult = usersRepository.Create(userToAdd);

            _tempUsers.Add(result.Id);
            _tempUsers.Add(addedresult.Id);

            var chatRepository = new ChatsRepository();
            var chat = chatRepository.Create(new[] { result.Id }, chatName);
            chatRepository.AddUser(chat.Id, addedresult.Id);
            var userChats = chatRepository.GetUserChats(addedresult.Id);

            _tempChats.Add(chat.Id);
            //asserts

            Assert.AreEqual(chat.Id, userChats.ElementAt(0).Id);
            Assert.AreEqual(chat.Name, userChats.ElementAt(0).Name);


        }
        
        [TestMethod]
        public void ShouldDeleteUserFromChatEntity()
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
            var usersRepository = new UsersRepository();
            var result = usersRepository.Create(user);
            var addedresult = usersRepository.Create(userToAdd);

            _tempUsers.Add(result.Id);
            _tempUsers.Add(addedresult.Id);

            var chatRepository = new ChatsRepository();
            var chat = chatRepository.Create(new[] { result.Id }, chatName);
            chatRepository.AddUser(chat.Id, addedresult.Id);
            chatRepository.DeleteUser(chat.Id, result.Id);
            var gotChat = chatRepository.Get(chat.Id);
            _tempChats.Add(chat.Id);
            //asserts

            Assert.AreEqual(chat.Members.Count(), gotChat.Members.Count());
            //Assert.AreEqual(chat.Name, userChats.ElementAt(0).Name);
        }

        [TestCleanup]
        public void Clean()
        {
            foreach (var id in _tempUsers)
                new UsersRepository().Delete(id);
            foreach (var id in _tempChats)
                new ChatsRepository().DeleteChat(id);
        }
    }
}
