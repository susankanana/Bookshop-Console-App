using BookShop_Console_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop_Console_App.Services.IServices
{
    internal interface IUser
    {
        Task<List<User>> GetAllUsers();
        Task<string> AddUser(AddUsers newuser);
        Task<User> GetUserByUsername(string username);
        

    }
}
