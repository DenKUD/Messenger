﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Messenger.Model;

namespace Messenger.DataLayer.Sql
{
    public class ChatsRepository : IChatsRepository
    {
        private readonly string _connectionString;
        private readonly IUsersRepository _usersRepository;

        public ChatsRepository(string connectionString, IUsersRepository usersRepository)
        {
            _connectionString = connectionString;
            _usersRepository = usersRepository;
        }

        public Chat Create(IEnumerable<Guid> members, string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var chat = new Chat
                    {
                        Name = name,
                        Id = Guid.NewGuid()
                    };
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = "insert into Chats (Id, Name) values (@id, @name)";
                        command.Parameters.AddWithValue("@id", chat.Id);
                        command.Parameters.AddWithValue("@name", chat.Name);

                        command.ExecuteNonQuery();
                    }

                    foreach (var userId in members)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.Transaction = transaction;
                            command.CommandText = "insert into chatmembers (chat_id, user_id) values (@chat_id, @user_id)";
                            command.Parameters.AddWithValue("@chat_id", chat.Id);
                            command.Parameters.AddWithValue("@user_id", userId);
                            command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    chat.Members = members.Select(x => _usersRepository.Get(x));
                    return chat;
                }
            }
        }

        public void DeleteChat(Guid chatId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "delete from chatmembers where chat_id = @chatid";
                    command.Parameters.AddWithValue("@chatid", chatId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private IEnumerable<User> GetChatMembers(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select user_id from chatmembers where chat_id = @chatid";
                    command.Parameters.AddWithValue("@chatid", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            yield return _usersRepository.Get(reader.GetGuid(reader.GetOrdinal("user_id")));
                    }
                }
            }
        }
        public IEnumerable<Chat> GetUserChats(Guid userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select id, name from chatmembers " +
                        "inner join chats on chatmembers.chat_id = chats.id where user_id = @userid";
                    command.Parameters.AddWithValue("@userid", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Chat
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("id")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                Members = GetChatMembers(reader.GetGuid(reader.GetOrdinal("id")))
                            };
                        }
                    }
                }
            }
        }

        public Chat Get(Guid chatId)
        {
            var chatMembers = GetChatMembers(chatId);
            Chat chat = new Chat { Members = chatMembers };
            using (var connection = new SqlConnection(_connectionString))
            {
                
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select * from chats where id = @chatid";
                    command.Parameters.AddWithValue("@chatid", chatId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new ArgumentException($"Чата с id {chatId} не существует");

                        chat.Id = reader.GetGuid(reader.GetOrdinal("id"));
                        chat.Name = reader.GetString(reader.GetOrdinal("name"));
                        
                    }
                }
            }
            return chat;
        }

        public void AddUser(Guid chatId, Guid userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                            
                    command.CommandText = "insert into chatmembers (chat_id, user_id) values (@chat_id, @user_id)";
                    command.Parameters.AddWithValue("@chat_id", chatId);
                    command.Parameters.AddWithValue("@user_id", userId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(Guid chatId, Guid userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {

                    command.CommandText = "delete from chatmembers  where chat_id=@chat_id AND user_id=@user_id";
                    command.Parameters.AddWithValue("@chat_id", chatId);
                    command.Parameters.AddWithValue("@user_id", userId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
