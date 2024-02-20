using BookShop_Console_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop_Console_App.Services.IServices
{
    internal interface IOrder
    {
        Task<List<Order>> GetAllOrders();
        Task AddOrder(AddOrder order);
    }
}
