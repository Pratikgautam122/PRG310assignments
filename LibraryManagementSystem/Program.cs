using System;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Service;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryService library = new LibraryService();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== Library Management System =====");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Add Magazine");
                Console.WriteLine("3. Display All Items");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook(library);
                        break;
                    case "2":
                        AddMagazine(library);
                        break;
                    case "3":
                        library.DisplayAllItems();
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddBook(LibraryService library)
        {
            try
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Author: ");
                string author = Console.ReadLine();

                Console.Write("Enter Publisher: ");
                string publisher = Console.ReadLine();

                Console.Write("Enter Publication Year: ");
                int year = int.Parse(Console.ReadLine());

                Book book = new Book(title, author, publisher, year);
                library.AddItem(book);
            }
            catch (InvalidItemDataException ex)
            {
                Console.WriteLine($"Validation Error: {ex.Message}");
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number for year.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void AddMagazine(LibraryService library)
        {
            try
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Publisher: ");
                string publisher = Console.ReadLine();

                Console.Write("Enter Publication Year: ");
                int year = int.Parse(Console.ReadLine());

                Console.Write("Enter Issue Number: ");
                int issueNumber = int.Parse(Console.ReadLine());

                Magazine magazine = new Magazine(title, publisher, year, issueNumber);
                library.AddItem(magazine);
            }
            catch (InvalidItemDataException ex)
            {
                Console.WriteLine($"Validation Error: {ex.Message}");
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter valid numbers for year and issue number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}