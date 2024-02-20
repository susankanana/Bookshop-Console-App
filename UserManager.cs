using BookShop_Console_App.Models;
using BookShop_Console_App.Services;
using BookShop_Console_App.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookShop_Console_App
{
    internal class UserManager
    {
        public UserServices userService = new UserServices();
        public BookServices bookServices = new BookServices();
        public OrderService orderService = new OrderService();


        //public BookManager dashboard = new BookManager();

        //private User _isLoggedIn;



        ////register users
        public async Task RegisterUser()
        {
            Console.WriteLine("===== Register =====");
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            var _users = await userService.GetAllUsers();
            // Check if the username already exists
            if (_users.Exists(u => u.username == username))
            {
                Console.WriteLine("Username already exists. Please choose a different one.");
                return;
            }
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();


            AddUsers newuser = new AddUsers() { username = username, email = email, role="user", password = password };
            //save user information 
            await saveUsers(newuser);
            Console.WriteLine("Registration successful!");
        }

        ////loginUsers
        public async Task LoginUser()
        {
            Console.WriteLine("===== Login =====");
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            if (username=="admin"&& password=="1234")
            {
                Console.WriteLine(" Welcome Admin");
                await loadAdminDashboard();
            }
            else
            {
                var _users = await userService.GetAllUsers();
                User user = _users.Find(u => u.username == username && u.password == password);

                if (user != null)
                {
                    //_isLoggedIn = user;
                    Console.WriteLine("Login successful!");
                    State.UserId = user.Id;
                    await loadUserDashboard();
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }
            }
        }

        private async Task loadUserDashboard()
        {
            Console.WriteLine("1. Show All books");
            Console.WriteLine("2. Show my Orders");

            var option = Console.ReadLine();
            var optionbool = int.TryParse(option, out int selectedOption);
            switch(selectedOption)
            {
                case 1:
                    Console.WriteLine("The books available are: ");
                    await ShowBooks();
                    break;
                case 2:
                    Console.WriteLine("Orders made are: ");
                    await ShowOrders();

                    break;
            }
        }
        public async Task ShowBooks()
        {
            var books = await bookServices.GetAll();
            Console.WriteLine($"Title \t Description \t Author");

            foreach (var book in books)
            {
                Console.WriteLine($"{book.id} \t {book.Title} \t {book.Description} \t {book.Author}");

            }

            Console.WriteLine("Select book to Buy:");
            var book1 = Console.ReadLine();
            var input = int.TryParse(book1, out int selectedbook);
            var book2 = await ShowSelectedBook(selectedbook);
            State.BookId = book2.id;
            

            var chosen = Console.ReadLine();
            bool ischosen = int.TryParse(chosen, out int selectedchosen);
            if (selectedchosen == 1)
            {
                await AddOrders();
            }

        }
        public async Task AddOrders()
        {
            var neworder = new AddOrder() { UserId = State.UserId, BookId = State.BookId };
            //save added book
            await saveOrders(neworder);
            Console.WriteLine("Book added successfully!");
        }

        private async Task saveOrders(AddOrder neworder)
        {
            await orderService.AddOrder(neworder);
            
        }

        public async Task ShowOrders()
        {
            var orders = await orderService.GetAllOrders();
            Console.WriteLine("All Orders:");
            foreach (var order in orders)
            {
                Console.WriteLine($"Order Id: {order.Id}, User Id: {order.UserId}, Book Id: {order.BookId}");
            }
            
        }
        private async Task<Book> ShowSelectedBook(int selectedbook)
        {
           Book book = await bookServices.GetBookById(selectedbook);
            Console.WriteLine($" Buy {book.Title}");
            Console.WriteLine("1. Buy Book");

            return book;
        }
         
        public async Task loadAdminDashboard()
        {
            Console.WriteLine("1. Show All books");
            Console.WriteLine("2. Add a book");
            var option = Console.ReadLine();
            var optionbool = int.TryParse(option, out int selectedOption);
            switch (selectedOption)
            {
                case 1:
                    Console.WriteLine("The books available are: ");
                    await ShowBooks();
                    break;
                case 2:
                    Console.WriteLine("Proceeding to add a book.");
                    await AddBook();
                    break;
            }

        }
        //Add a book
        public async Task AddBook()
        {
            Console.WriteLine("===== Create a book =====");
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();
            var _books = await bookServices.GetAll();
            // Check if the book title already exists
            if (_books.Exists(t => t.Title == title))
            {
                Console.WriteLine("Book already exists. Please add a different book.");
                return;
            }
            Console.Write("Add book description: ");
            string description = Console.ReadLine();
            Console.Write("Add book authur: ");
            string author = Console.ReadLine();


            AddBook newbook = new AddBook() { Title = title, Description = description, Author = author };
            //save added book
            await saveBook(newbook);
            Console.WriteLine("Book added successfully!");
        }

        //save users to file
        public async Task saveUsers(AddUsers newuser)
        {
            var response = await userService.AddUser(newuser);
            Console.WriteLine(response);
        }
        public async Task saveBook(AddBook newbook)
        {
            var response = await bookServices.AddBook(newbook);
            Console.WriteLine(response);
        }
        //public async Task saveorders(AddOrder neworder)
        //{
        //    var response = await orderservice.addorder(neworder);
        //    Console.WriteLine(response);
        //}
    }
}

