using BookShop_Console_App.Models;
using BookShop_Console_App.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookShop_Console_App.Services
{
    public class UserServices : IUser

    {
        private readonly HttpClient _httpClient;
        private readonly string _URL = "http://localhost:3000/users";
        public UserServices()
        {
            _httpClient = new HttpClient();
        }
        public async Task<string> AddUser(AddUsers newuser)
        {
            try
            {
                var users = JsonConvert.SerializeObject(newuser);
                var body = new StringContent(users, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_URL, body);

                if (response.IsSuccessStatusCode)
                {

                    return "User added successfully";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            
            return "";
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var response = await _httpClient.GetAsync(_URL);
                var content = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(content);

                if (response.IsSuccessStatusCode)
                {
                    return users;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            
            return new List<User>();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            try
            {
                var response = await _httpClient.GetAsync(_URL + "/" + username);
                var content = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(content);

                if (response.IsSuccessStatusCode)
                {
                    return user;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            
            return new User();
        }

        

    }
}
