using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Messenger.Model;
using System.Text;

namespace Messenger.DataLayer.Sql.Tests
{
    [TestClass]
    public class MessageRepositoryTest
    {
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        private readonly List<Guid> _tempMessages = new List<Guid>();
        private readonly List<Guid> _tempUsers = new List<Guid>();
        private readonly List<Guid> _tempChats = new List<Guid>();

        [TestMethod]
        public void ShouldCreateMessage()
        { 
            // arrange
            var user = new User
            {
                Name = "testUser",
                Userpic = Encoding.UTF8.GetBytes("ava"),
                Password = "password",
                Bio = "test"
            };
            var chatName = "tst";
            
            //act
            var usersRepository = new UsersRepository(ConnectionString);
            var testUser = usersRepository.Create(user);
            _tempUsers.Add(testUser.Id);

            var chatsRepository = new ChatsRepository(ConnectionString,usersRepository);
            var testchat=chatsRepository.Create(new[] {user.Id}, chatName);
            _tempChats.Add(testchat.Id);
            var message = new Message
            {
                //Id = Guid.NewGuid(),
                User = user,
                Chat=testchat,
                Text = "test",
                dtime = DateTime.Now,
                Body = Encoding.UTF8.GetBytes("body"),
                SelfDestroy = true,
                IsRead = false

            };
            var messageRepository = new MessageRepository(ConnectionString,usersRepository,chatsRepository);
            var result = messageRepository.CreateMessage(message);

            _tempMessages.Add(result.Id);

            
            //asserts
            Assert.AreEqual(message.User, result.User);
            Assert.AreEqual(message.Chat, result.Chat);
            Assert.AreEqual(message.Text, result.Text);
            Assert.AreEqual(message.dtime, result.dtime);
            Assert.AreEqual(message.Body, result.Body);
            Assert.AreEqual(message.SelfDestroy, result.SelfDestroy);
            Assert.AreEqual(message.IsRead, result.IsRead);
            
            
        }

        [TestMethod]
        public void ShouldGetChatMessagesIds()
        {
            // arrange
            var user = new User
            {
                Name = "testUser",
                Userpic = Encoding.UTF8.GetBytes("ava"),
                Password = "password",
                Bio = "test"
            };
            var chatName = "tst";

            //act
            var usersRepository = new UsersRepository(ConnectionString);
            var testUser = usersRepository.Create(user);
            _tempUsers.Add(testUser.Id);

            var chatsrepository = new ChatsRepository(ConnectionString, usersRepository);
            var testchat = chatsrepository.Create(new[] { user.Id }, chatName);
            _tempChats.Add(testchat.Id);
            var message = new Message
            {
                
                User = user,
                Chat = testchat,
                Text = "test",
                dtime = DateTime.Now,
                Body = Encoding.UTF8.GetBytes("body"),
                SelfDestroy = true,
                IsRead = false

            };
            var messageRepository = new MessageRepository(ConnectionString,usersRepository,chatsrepository);
            var result = messageRepository.CreateMessage(message);

            _tempMessages.Add(result.Id);

            var gotmessagesid = messageRepository.GetChatMessagesIds(testchat.Id);
            //asserts
            
            Assert.ReferenceEquals(result.Id, gotmessagesid);
        }

        [TestMethod]
        public void ShouldGetMessage()
        {
            // arrange
            var user = new User
            {
                Name = "testUser",
                Userpic = Encoding.UTF8.GetBytes("ava"),
                Password = "password",
                Bio = "test"
            };
            var chatName = "tst";

            //act
            var usersRepository = new UsersRepository(ConnectionString);
            var testUser = usersRepository.Create(user);
            _tempUsers.Add(testUser.Id);

            var chatsrepository = new ChatsRepository(ConnectionString, usersRepository);
            var testchat = chatsrepository.Create(new[] { user.Id }, chatName);
            _tempChats.Add(testchat.Id);
            var messageNoAttach = new Message
            {

                User = user,
                Chat = testchat,
                Text = "test",
                dtime = DateTime.Now,
                //Body = Encoding.UTF8.GetBytes("body"),
                SelfDestroy = true,
                IsRead = false

            };
            var messageWithAttach = new Message
            {

                User = user,
                Chat = testchat,
                Text = "test",
                dtime = DateTime.Now,
                Body = Encoding.UTF8.GetBytes("body"),
                SelfDestroy = true,
                IsRead = false

            };
            var messageRepository = new MessageRepository(ConnectionString, usersRepository, chatsrepository);
            var resultNoattach = messageRepository.CreateMessage(messageNoAttach);
            var resultWithattach = messageRepository.CreateMessage(messageWithAttach);

            _tempMessages.Add(resultNoattach.Id);
            _tempMessages.Add(resultWithattach.Id);

            var gotmessageNoAttach = messageRepository.GetMessage(resultNoattach.Id);
            var gotmessageWithAttach = messageRepository.GetMessage(resultWithattach.Id);
            //asserts

            Assert.ReferenceEquals(resultNoattach, gotmessageNoAttach);
            Assert.ReferenceEquals(resultNoattach, gotmessageWithAttach);
        }

        [TestCleanup]
        public void Clean()
        {
            foreach (var id in _tempMessages)
                new MessageRepository(ConnectionString, new UsersRepository(ConnectionString),new ChatsRepository(ConnectionString, new UsersRepository(ConnectionString))).DeleteMessage(id);
            foreach (var id in _tempUsers)
                new UsersRepository(ConnectionString).Delete(id);
            foreach (var id in _tempChats)
                new ChatsRepository(ConnectionString, new UsersRepository(ConnectionString)).DeleteChat(id);

        }
    }
}
