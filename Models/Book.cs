﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop_Console_App.Models
{
    public class Book
    {
        public int id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;



        //public Book(string Title, string Description, string Author)
        //{
        //    bookId = Guid.NewGuid().ToString();
        //    Title = Title;
        //    Description = Description;
        //    Author = Author;
        //}
    }
}
