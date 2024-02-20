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
     class OrderService : IOrder
    {

        private readonly HttpClient _httpClient;
        private readonly string _URL = "http://localhost:3000/orders";

        public OrderService() {
            _httpClient = new HttpClient();
    }

        public async Task<List<Order>> GetAllOrders()
        {
            try
            {
                var response = await _httpClient.GetAsync(_URL);
                var content = await response.Content.ReadAsStringAsync();
                var orders = JsonConvert.DeserializeObject<List<Order>>(content);

                if (response.IsSuccessStatusCode)
                {
                    return orders;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            

            return new List<Order>();
        }
        public async Task AddOrder(AddOrder neworder)
        {
            try
            {
                string orders = JsonConvert.SerializeObject(neworder);
                var body = new StringContent(orders, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_URL, body);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            
        }

     
    }
}
