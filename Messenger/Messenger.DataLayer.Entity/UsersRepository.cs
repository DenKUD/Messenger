using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Model;

namespace Messenger.DataLayer.Entity
{
    public class UsersRepository : IUsersRepository
    {
        public User Create(User user)
        {
            user.Id = Guid.NewGuid();
            using (var db = new MessengerEntities())
            {
                db.Users.Add(new Users
                {
                    Id = user.Id,
                    Bio = user.Bio,
                    Username = user.Name,
                    User_pic=user.Userpic,
                    Password=user.Password
                    
                });
                db.SaveChanges();
            }
            return user;
        }

        public void Delete(Guid id)
        {
            using (var db = new MessengerEntities())
            {
                var userToDelete = db.Users.Find(id);
                db.Users.Remove(userToDelete);
                db.SaveChanges();
            }
        }

        public IEnumerable<Guid> FindUserIdByName(string name)
        {
            using (var db = new MessengerEntities())
            {
                var result =db.Users.Where(u => u.Username == name);
                foreach (Users users in result)
                    yield return users.Id;
            }

        }

        public User Get(Guid id)
        {
            User gotUser;
            using (var db = new MessengerEntities())
            {
                var result = db.Users.Find(id);
                gotUser = new User
                {
                    Id = result.Id,
                    Name= result.Username,
                    Bio= result.Bio,
                    Password= result.Password,
                    Userpic=result.User_pic
                };
                
            }
            return gotUser;
        }

        public User Update(Guid id, User newUser)
        {
            newUser.Id = id;
            using (var db = new MessengerEntities())
            {
                var userToUpdate = db.Users.Find(id);
                userToUpdate.Username = newUser.Name;
                userToUpdate.User_pic = newUser.Userpic;
                userToUpdate.Password = newUser.Password;
                userToUpdate.Bio = newUser.Bio;
                db.SaveChanges();
            }
            return newUser;
        }
    }
}
