﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop_Console_App.Models
{
    internal class Order
    {
        public int Id { get; set; } 
        public User UserId{ get; set; }
        public Book BookId { get; set; }


        

    }
}
