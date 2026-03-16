using System;
using System.Linq;

namespace PasswordManager;

class Program
{
    static void Main()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Welcome to your password manager");
            Console.WriteLine("Please Select an option: ");
            Console.WriteLine("1. Check Password Strength");
            Console.WriteLine("2. Generate Password");
            Console.WriteLine("3. Save Password");
            Console.WriteLine("4. Exit");

            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                checkpasswordstrength();
               

            }
            else if (choice == "2")
            {
                string newpassword = PassGen(12);
                Console.WriteLine("Generating Password....");
                Console.WriteLine("Your new password is: " + newpassword);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else if (choice == "3")
            {
                // Save Password - not implemented yet
            }
            else if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }
    }

    static void checkpasswordstrength()
    {
        Console.WriteLine("Enter your password: ");
        string? password = Console.ReadLine();

        if (string.IsNullOrEmpty(password))
        {
            Console.WriteLine("No password entered.");
            return;
        }

        bool hasDigit = password.Any(char.IsDigit);
        bool hasLetter = password.Any(char.IsLetter);

        if (password.Length < 8)
        {
            Console.WriteLine(" Password is very weak (Under 8 Characters)");
            Console.WriteLine("Press any key to continue");
             Console.ReadKey();
            return;
        }
        else if (password.Length < 12 && hasDigit && !hasLetter)
        {
            Console.WriteLine("Password is weak (Under 12 characters and only contains digits)");
            Console.WriteLine("Press any key to continue");
             Console.ReadKey();
            return;
        }
        else if (password.Length < 12 && (!hasDigit || !hasLetter))
        {
            Console.WriteLine("Password is weak (Under 12 characters, not a mix of digits and letters)");
            Console.WriteLine("Press any key to continue");
             Console.ReadKey();
            return;
        }
        else if (password.Length >= 12 && hasDigit && hasLetter)
        {
            Console.WriteLine("Password is strong with at least 12 characters and a mix of digits and letters");
             Console.WriteLine("Press any key to continue");
             Console.ReadKey();
            return;
        }
    }

    static string PassGen(int length)
    {
        Random rnd = new Random();
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        char[] buffer = new char[length];
        for (int i = 0; i < length; i++)
            buffer[i] = chars[rnd.Next(chars.Length)];
        return new string(buffer);
    }
}
