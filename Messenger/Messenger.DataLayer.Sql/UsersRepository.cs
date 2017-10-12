using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Messenger.Model;

namespace Messenger.DataLayer.Sql
{
    public class UsersRepository : IUsersRepository
    {
        private readonly string _connectionString;

        public UsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User Create(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "insert into Messenger.dbo.Users (id, username, password, user_pic, bio) values (@id, @name, @password, @pic, @bio)";
                    user.Id = Guid.NewGuid();
                    command.Parameters.AddWithValue("@id", user.Id);
                    command.Parameters.AddWithValue("@name", user.Name);
                    command.Parameters.AddWithValue("@pic", user.Userpic);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@bio", user.Bio);

                    command.ExecuteNonQuery();
                    return user;
                }
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "delete from Messenger.dbo.users where id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public User Get(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select top(1) id, username, password, user_pic, bio  from Messenger.dbo.users where id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new ArgumentException($"Пользователь с id {id} не найден");
                        return new User
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("id")),
                            Userpic = reader.GetSqlBinary(reader.GetOrdinal("user_pic")).Value,
                            Name = reader.GetString(reader.GetOrdinal("username")),
                            Password = reader.GetString(reader.GetOrdinal("password")),
                            Bio= reader.GetString(reader.GetOrdinal("bio"))
                        };
                    }
                }
            }
        }
    }
}
