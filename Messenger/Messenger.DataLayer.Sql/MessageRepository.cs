﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Messenger.Model;

namespace Messenger.DataLayer.Sql
{
    public class MessageRepository : IMessagesRepository
    {
        private readonly string _connectionString;
        private readonly IUsersRepository _usersRepository;
        private readonly IChatsRepository _chatsRepository;

        public MessageRepository(string connectionString, IUsersRepository userRepository,
            IChatsRepository chatsRepository)
        {
            _connectionString = connectionString;
            _usersRepository = userRepository;
            _chatsRepository = chatsRepository;
        }

        public Message CreateMessage(Message message)
        {   
            using (var connection = new SqlConnection(_connectionString))
            {
                Guid attach_id = Guid.NewGuid();// Attach identifier in DB
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {//Attach should be inserted first if it exist
                    if (message.Body != null)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.Transaction = transaction;
                            command.CommandText = "insert into Messenger.dbo.Attaches (Id, Content) values (@id, @Content)";

                            command.Parameters.AddWithValue("@Id", attach_id);
                            command.Parameters.AddWithValue("@Content", message.Body);

                            command.ExecuteNonQuery();
                        }
                        using (var command = connection.CreateCommand())
                        {
                            command.Transaction = transaction;
                            command.CommandText = "insert into Messenger.dbo.Messages (Id, Chat_id, User_id, Datetime, text, SelfDestructable, isRead, Attach_id) " +
                                "values (@id, @Chat_id, @User_id, @Datetime, @text, @SelfDestructable, @isRead, @Attach_id)";
                            message.Id = Guid.NewGuid();

                            command.Parameters.AddWithValue("@Id", message.Id);
                            command.Parameters.AddWithValue("@Chat_id", message.Chat.Id);
                            command.Parameters.AddWithValue("@User_id", message.User.Id);
                            command.Parameters.AddWithValue("@Datetime", message.dtime);
                            command.Parameters.AddWithValue("@text", message.Text);
                            command.Parameters.AddWithValue("@SelfDestructable", message.SelfDestroy);
                            command.Parameters.AddWithValue("@isRead", message.IsRead);
                            command.Parameters.AddWithValue("@Attach_id", attach_id);
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                        using (var command = connection.CreateCommand())
                        {
                            command.Transaction = transaction;
                            command.CommandText = "insert into Messenger.dbo.Messages (Id, Chat_id, User_id, Datetime, text, SelfDestructable, isRead) " +
                                "values (@id, @Chat_id, @User_id, @Datetime, @text, @SelfDestructable, @isRead)";
                            message.Id = Guid.NewGuid();

                            command.Parameters.AddWithValue("@Id", message.Id);
                            command.Parameters.AddWithValue("@Chat_id", message.Chat.Id);
                            command.Parameters.AddWithValue("@User_id", message.User.Id);
                            command.Parameters.AddWithValue("@Datetime", message.dtime);
                            command.Parameters.AddWithValue("@text", message.Text);
                            command.Parameters.AddWithValue("@SelfDestructable", message.SelfDestroy);
                            command.Parameters.AddWithValue("@isRead", message.IsRead);
                          
                            command.ExecuteNonQuery();
                        }
                    transaction.Commit();
                    return message;
                }
            }
            
        }

        
        public void DeleteMessage(Guid messageId)
        {   //Does not delete Attach from Messenger.dbo.Attaches yet
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "delete from Messenger.dbo.messages where Id = @id";
                    command.Parameters.AddWithValue("@id", messageId);
                    command.ExecuteNonQuery();
                }
                
            }
        }

        

        public IEnumerable<Guid> GetChatMessagesIds(Guid chatId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select Id from Messenger.dbo.messages where chat_id = @chatid";
                    command.Parameters.AddWithValue("@chatid", chatId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            yield return  reader.GetGuid(reader.GetOrdinal("id"));
                    }
                }
            }
        }

        public Message GetMessage(Guid messageId)
        {
            Message gotMessage=null;
            Guid attachId=Guid.Empty;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select * from Messenger.dbo.messages where id = @messageid";
                    command.Parameters.AddWithValue("@messageid", messageId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new ArgumentException($"Сообщение с id {messageId} не найдено");
                        gotMessage = new Message
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("id")),
                            User = _usersRepository.Get(reader.GetGuid(reader.GetOrdinal("User_id"))),
                            Chat = _chatsRepository.Get(reader.GetGuid(reader.GetOrdinal("chat_id"))),
                            dtime = reader.GetDateTime(reader.GetOrdinal("Datetime")),
                            SelfDestroy = reader.GetBoolean(reader.GetOrdinal("SelfDestructable")),
                            IsRead = reader.GetBoolean(reader.GetOrdinal("isRead"))
                        };
                        try //if attach_id is not null get attach_id
                        {
                            attachId = reader.GetGuid(reader.GetOrdinal("attach_id"));
                        }
                        catch(System.Data.SqlTypes.SqlNullValueException)
                        {// if it is there is no attach. set attachId=Guid.Empty 
                            attachId = Guid.Empty;
                        }
                    }
                }
            }
             if(attachId!= Guid.Empty)  //Get attach from Messenger.dbo.attches, if attach exists
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "select Content from Messenger.dbo.attaches where id = @id";
                        command.Parameters.AddWithValue("@id", attachId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                                throw new ArgumentException($"Вложение не найдено");
                            gotMessage.Body = reader.GetSqlBinary(reader.GetOrdinal("content")).Value;
                        }
                    }
                }
            return gotMessage;  
        }
    }
}
