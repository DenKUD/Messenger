using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Messenger.DataLayer.Entity;
using Messenger.Model;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Messenger.DataLayer.Entity.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        List<Guid> _tempUsers= new List<Guid>();
        [TestMethod]
        public void ShouldCreateUserEntity()
        {
            //arrange
            var user = new User
            {
                Name = "Userrrr",
                Bio = "wahPssww",
                Password = "WowWowPalehche",
                Userpic = Encoding.UTF8.GetBytes("ava")
            };

            //act
            var db = new UsersRepository();
            var result =  db.Create(user);
            _tempUsers.Add(result.Id);

            //assert
            Assert.AreEqual(user.Name, result.Name);
            Assert.AreEqual(user.Userpic, result.Userpic);
            Assert.AreEqual(user.Password, result.Password);
            Assert.AreEqual(user.Bio, result.Bio);
        }

        [TestMethod]
        public void ShouldGetUserEntity()
        {
            //arrange
            var user = new User
            {
                Name = "Userrrr",
                Bio = "wahPssww",
                Password = "WowWowPalehche",
                Userpic = Encoding.UTF8.GetBytes("ava")
            };

            //act
            var db = new UsersRepository();
            user = db.Create(user);
            _tempUsers.Add(user.Id); 
            var result = db.Get(user.Id);

            //assert
            Assert.AreEqual(user.Name, result.Name);
            CollectionAssert.AreEqual(user.Userpic, result.Userpic);
            Assert.AreEqual(user.Password, result.Password);
            Assert.AreEqual(user.Bio, result.Bio);
        }

        [TestMethod]
        public void shouldfindUserByNameEntity()
        {
            // arrange

            var user = new User
            {
                Name = "UserrrrVeryUnique",
                Bio = "wahPssww",
                Password = "WowWowPalehche",
                Userpic = Encoding.UTF8.GetBytes("ava")
            };

            //act
            var repository = new UsersRepository();
            var resultUser = repository.Create(user);

            _tempUsers.Add(resultUser.Id);



            var foundUser = repository.FindUserIdByName(resultUser.Name);
            //asserts
            Assert.AreEqual(resultUser.Id, foundUser.Single());

        }

        [TestMethod]
        public void shouldUpdateUserEntity()
        {
            // arrange

            var user = new User
            {
                Name = "testUserEntity",
                Userpic = Encoding.UTF8.GetBytes("ava"),
                Password = "password",
                Bio = "test"
            };

            //act
            var repository = new UsersRepository();
            var result = repository.Create(user);

            _tempUsers.Add(result.Id);

            var newUser = new User
            {
                Name = "newtestUserEntity",
                Userpic = Encoding.UTF8.GetBytes("newava"),
                Password = "newpassword",
                Bio = "newtest"
            };
            repository.Update(result.Id, newUser);
            var newResult = repository.Get(result.Id);

            //asserts
            Assert.AreEqual(newUser.Name, newResult.Name);
            CollectionAssert.AreEqual(newUser.Userpic, newResult.Userpic);
            Assert.AreEqual(newUser.Password, newResult.Password);
            Assert.AreEqual(newUser.Bio, newResult.Bio);
        }

        [TestCleanup]
        public void Clean()
        {
            foreach (var id in _tempUsers) new UsersRepository().Delete(id);
    
        }
    }
}
