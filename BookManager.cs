using BookShop_Console_App.Models;
using BookShop_Console_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop_Console_App
{
    internal class BookManager
    {
        
        //private readonly string _URL = "http://localhost:3000/users";

        //public BookServices bookServices = new BookServices();
        //public List<Book> Books = new List<Book>();
        //private string _filePath;


        //public BookManager()
        //{
            
        //    LoadBooks();
        //}

        ////add a book
        //public async Task AddBook()
        //{
        //    Console.WriteLine("===== Add Book =====");
        //    Console.Write("Enter Book Title: ");
        //    string Title = Console.ReadLine();
        //    Console.Write("Enter Book Description: ");
        //    string Description = Console.ReadLine();
        //    Console.Write("Enter Book Author: ");
        //    string Author = Console.ReadLine();

        //    var _books = await bookServices.GetAllBooks();
        //    AddBook newBook = new AddBook() { Title = Title, Description = Description, Author = Author };

        //    // book file exists 
        //    if (_books.Exists(t => t.Title == Title))
        //    {
        //        try
        //        {
        //            string[] lines = File.ReadAllLines(_URL);

        //            foreach (var line in lines)
        //            {
        //                string[] parts = line.Split(':');
        //                if (parts.Length == 4)
        //                {

        //                    string storedTitle = parts[1].Trim();
        //                    string storedDescription = parts[2].Trim();
        //                    string storedAuthor = parts[3].Trim();
        //                    Books.Add(new Book(
        //                        storedTitle,
        //                        storedDescription,
        //                        storedAuthor
        //                        ));
        //                }
        //            }
        //        }
        //        catch (IOException ex)
        //        {
        //            Console.WriteLine($"Error reading from file: {ex.Message}");
        //        }
        //    }
        //    else
        //    {
        //        //  file does not exist
        //        if (!File.Exists(_URL))
        //        {
        //            // create the file
        //            using (File.Create(_URL))
        //            {
        //                Console.WriteLine($"File '{_URL}' created.");
        //            }
        //        }
        //    }

        //    //save book information 
        //    Books.Add(newBook);
        //    saveBook();
        //    Console.WriteLine("Book Registered successfully!");
        //}

        //private void saveBook()
        //{
        //    try
        //    {
        //        List<string> userLines = new List<string>();

        //        foreach (var book in Books)
        //        {
        //            userLines.Add($"{book.bookId}:{book.Title}:{book.Description}:{book.Author}");
        //        }
        //        File.WriteAllLines(_filePath, userLines);
        //    }
        //    catch (IOException ex)
        //    {
        //        Console.WriteLine($"Error writing to file: {ex.Message}");
        //    }
        //}

        ////load books
        //public void LoadBooks()
        //{
        //    //file exists
        //    if (File.Exists(_filePath))
        //    {
        //        try
        //        {
        //            string[] lines = File.ReadAllLines(_filePath);
        //            foreach (var line in lines)
        //            {
        //                string[] parts = line.Split(':');
        //                if (parts.Length == 4)
        //                {
        //                    string storedId = parts[0].Trim();
        //                    string storedTitle = parts[1].Trim();
        //                    string storedDescription = parts[2].Trim();
        //                    string storedAuthor = parts[3].Trim();
        //                    Books.Add(new Book(
        //                        storedTitle,
        //                        storedDescription,
        //                        storedAuthor
        //                        ));
        //                }
        //            }
        //        }
        //        catch (IOException ex)
        //        {
        //            Console.WriteLine($"Error reading from file: {ex.Message}");
        //        }
        //    }
        //    else
        //    {
        //        //  file does not exist
        //        if (!File.Exists(_filePath))
        //        {
        //            // If not, create the file
        //            using (File.Create(_filePath))
        //            {
        //                Console.WriteLine($"File '{_filePath}' created.");
        //            }
        //        }
        //    }
        //}

        ////show books
        //public async Task ShowBooks()
        //{
        //    var books = await bookServices.GetAll();
        //    Console.WriteLine($"Title \t Description \t Author");

        //    foreach(var book in books)
        //    {
        //        Console.WriteLine("{book.Title} \t {book.Description} \t {book.Author}");
        //    }


            
        //}

        ////buy book
        //public async Task BuyBook() 
        //{
        //    Console.WriteLine("Enter the ID of the book you want to buy");
        //    var bookIdToBuy = Console.ReadLine();
        //    var output = int.TryParse(bookIdToBuy, out var bookId);

        //    if (bookId != null)
        //    {
        //        var bookToBuy = Books.Find(a => a.Equals(bookId));
        //        Console.WriteLine(bookToBuy);
                
        //    }

        //}
    }
}

