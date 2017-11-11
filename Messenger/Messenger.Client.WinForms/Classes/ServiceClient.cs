using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Messenger.Model;
using System.Runtime.Serialization.Json;

namespace Messenger.Client.WinForms
{
    public class ServiceClient
    {
        private readonly HttpClient _client;

        public ServiceClient(string connectionString)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(connectionString);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }
        #region Users region
        public User GetUser(Guid Id)
        {
            string uri = "users/" + Id.ToString();
            var result =  _client.GetAsync(uri).Result.Content.ReadAsAsync<User>().Result;
            if (result == null) throw new ArgumentException("Пользователь не найден");
            return result;
        }

        public User CreateUser(User user)
        {
            string uri = "users";
            var result = _client.PostAsJsonAsync(uri, user).Result;
            if (result.IsSuccessStatusCode) return result.Content.ReadAsAsync<User>().Result;
            else return null;
        }

        public IEnumerable<User> GetUserByUsername(string username)
        {
            string uri = "users/username/" + username;
            List<User> result = new List<User>();
            var usersIds = _client.GetAsync(uri).Result.Content.ReadAsAsync<List<Guid>>().Result;
            if (usersIds == null) throw new ArgumentException("Пользователь не найден");
            foreach (Guid id in usersIds)
                result.Add(GetUser(id));
            return result;
        }

        public string DeleteUser(Guid Id)
        {
            string uri = "users/" + Id.ToString();
            var result = _client.DeleteAsync(uri).Result.StatusCode;//.Content.ReadAsAsync<Chat>().Result;
            return result.ToString();
        }

        public User UpdateUser(Guid Id,User user)
        {
            string uri = "users/" + Id.ToString();
            var result = _client.PutAsJsonAsync(uri, user).Result.Content.ReadAsAsync<User>().Result;
            return result;
        }
        #endregion

        #region Chats region
        public Chat GetChat(Guid Id)
        {
            string uri = "chats/" + Id.ToString();
            var result = _client.GetAsync(uri).Result.Content.ReadAsAsync<Chat>().Result;
            return result;
        }

        public IEnumerable<Chat> GetUserChats(Guid Id)
        {
            string uri = "userchats/" + Id.ToString();
            var result = _client.GetAsync(uri).Result.Content.ReadAsAsync<List<Chat>>().Result;
            return result;
        }

        public Chat CreateChat(IEnumerable<Guid> members, string chatName)
        {
            string uri = "chats/" + chatName;
            var result = _client.PostAsJsonAsync(uri, members).Result.Content.ReadAsAsync<Chat>().Result;
            return result;
        }

        public string DeleteChat(Guid Id)
        {
            string uri = "chats/" + Id.ToString();
            var result = _client.DeleteAsync(uri).Result.StatusCode;//.Content.ReadAsAsync<Chat>().Result;
            return result.ToString();
        }

        public string AddUserToChat(Guid newMemberId,Guid chatId)
        {
            string uri = "chats/" + chatId.ToString()+"/"+newMemberId.ToString();
            var result= _client.PutAsJsonAsync(uri, "").Result;
            return result.ToString();
        }

        public string DeleteUserFromChat(Guid chatId, Guid userId)
        {
            string uri = "chats/" + chatId.ToString() + "/" + userId.ToString();
            var result = _client.DeleteAsync(uri).Result;
            return result.ToString();
        }
        #endregion
        #region Messeges region
        public Message GetMessage(Guid Id)
        {
            string uri = "messages/" + Id.ToString();
            var result =  _client.GetAsync(uri).Result.Content.ReadAsAsync<Message>().Result;
            return result;
        }

        public void CreateMessage(Message message)
        {
            string uri = "messages";
           
            var result = _client.PostAsJsonAsync(uri, message);//.Result.Content.ReadAsAsync<Message>().Result;
            
            //return result;
        }

        public string DeleteMessage(Guid id)
        {
            string uri = "messages/" + id.ToString();
            var result = _client.DeleteAsync(uri).Result;
            return result.ToString();
        }

        public Message UpdateMessage(Message message,Guid id)
        {
            string uri = "messages/" + id.ToString();
            var result = _client.PostAsJsonAsync(uri, message).Result.Content.ReadAsAsync<Message>().Result;
            return result;
        }
        
        public IEnumerable<Guid> GetChatMessegesIds(Guid id)
        {
            string uri = "messages/chat/" + id.ToString();
            var result =   _client.GetAsync(uri).Result.Content.ReadAsAsync<List<Guid>>().Result;
            return result;
        }

        #endregion  

    }
}
