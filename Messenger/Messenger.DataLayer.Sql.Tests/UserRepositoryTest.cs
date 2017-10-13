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
        private readonly List<Guid> _tempChats = new List<Guid>();

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
        public void ShouldGetUser()
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
            User gotUser = new UsersRepository(ConnectionString).Get(result.Id);

            //asserts
            Assert.AreEqual(user.Name, gotUser.Name);
            CollectionAssert.AreEqual(user.Userpic, gotUser.Userpic);
            Assert.AreEqual(user.Password, gotUser.Password);
            Assert.AreEqual(user.Bio, gotUser.Bio);
        }

        
        [TestCleanup]
        public void Clean()
        {
            foreach (var id in _tempUsers)
                new UsersRepository(ConnectionString).Delete(id);
            foreach (var id in _tempChats)
                new ChatsRepository(ConnectionString,new UsersRepository(ConnectionString)).DeleteChat(id);
        }
    }
    
}
