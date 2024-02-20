using BookShop_Console_App.Models;
using BookShop_Console_App.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookShop_Console_App.Services
{
    internal class BookServices : IBook
    {
        private readonly HttpClient _httpClient;
        private readonly string _URL = "http://localhost:3000/books";

        public BookServices() {
        
        _httpClient = new HttpClient();
        }

        public async Task<string> AddBook(AddBook newbook)
        {
            try
            {
                var books = JsonConvert.SerializeObject(newbook);
                var body = new StringContent(books);
                var response = await _httpClient.PostAsync(_URL, body);

                if (response.IsSuccessStatusCode)
                {

                    return "Book added successfully";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            
            return "";
            
        }


        public async Task<List<Book>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetAsync(_URL);
                var content = await response.Content.ReadAsStringAsync();
                var books = JsonConvert.DeserializeObject<List<Book>>(content);

                if (response.IsSuccessStatusCode)
                {
                    return books;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            
            return new List<Book>();
        }

        public async Task<Book> GetBookById(int ID)
        {
            try
            {
                var response = await _httpClient.GetAsync(_URL + "/" + ID);
                var content = await response.Content.ReadAsStringAsync();
                var books = JsonConvert.DeserializeObject<Book>(content);

                if (response.IsSuccessStatusCode)
                {
                    return books;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            
            return new Book();
        }
        
    }
}
