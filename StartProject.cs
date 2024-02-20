using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop_Console_App
{
    public class StartProject
    {
        UserManager userManager = new UserManager();

        public async Task startMenu()
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Dashboard");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            var input = Console.ReadLine();
            var output = int.TryParse(input, out int choice);
            await switchUser(choice);
        }
        public async Task switchUser(int choice)
        {
            switch (choice)
            {
                case 1:
                    await userManager.RegisterUser();
                    break;
                case 2:
                    await userManager.LoginUser();
                    break;
                case 3:
                    Console.WriteLine("login");
                    break;
                case 4:
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
