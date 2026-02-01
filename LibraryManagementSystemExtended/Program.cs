using System;
using LibraryManagementSystemExtended.Model;
using LibraryManagementSystemExtended.Service;

namespace LibraryManagementSystemExtended
{
    // Main program - handles console UI and user input
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
                Console.WriteLine("3. Add Newspaper");
                Console.WriteLine("4. Display All Items");
                Console.WriteLine("5. Search by Title");
                Console.WriteLine("6. Search by Author");
                Console.WriteLine("7. Sort by Title");
                Console.WriteLine("8. Sort by Year");
                Console.WriteLine("9. Remove Item");
                Console.WriteLine("10. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1": AddBook(library); break;
                    case "2": AddMagazine(library); break;
                    case "3": AddNewspaper(library); break;
                    case "4": library.DisplayAllItems(); break;
                    case "5": SearchByTitle(library); break;
                    case "6": SearchByAuthor(library); break;
                    case "7": library.SortByTitle(); break;
                    case "8": library.SortByYear(); break;
                    case "9": RemoveItem(library); break;
                    case "10":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Add book with user input validation
        static void AddBook(LibraryService library)
        {
            try
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Author: ");
                string author = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Publisher: ");
                string publisher = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Publication Year: ");
                string yearInput = Console.ReadLine() ?? string.Empty;
                if (!int.TryParse(yearInput, out int year))
                    throw new FormatException();

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

        // Add magazine with user input validation
        static void AddMagazine(LibraryService library)
        {
            try
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Publisher: ");
                string publisher = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Publication Year: ");
                string yearInput = Console.ReadLine() ?? string.Empty;
                if (!int.TryParse(yearInput, out int year))
                    throw new FormatException();

                Console.Write("Enter Issue Number: ");
                string issueInput = Console.ReadLine() ?? string.Empty;
                if (!int.TryParse(issueInput, out int issueNumber))
                    throw new FormatException();

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

        // Add newspaper with user input validation
        static void AddNewspaper(LibraryService library)
        {
            try
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Editor: ");
                string editor = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Publisher: ");
                string publisher = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Publication Year: ");
                string yearInput = Console.ReadLine() ?? string.Empty;
                if (!int.TryParse(yearInput, out int year))
                    throw new FormatException();

                Newspaper newspaper = new Newspaper(title, editor, publisher, year);
                library.AddItem(newspaper);
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

        static void SearchByTitle(LibraryService library)
        {
            Console.Write("Enter title to search: ");
            string searchTitle = Console.ReadLine() ?? string.Empty;
            library.SearchByTitle(searchTitle);
        }

        static void SearchByAuthor(LibraryService library)
        {
            Console.Write("Enter author name to search: ");
            string searchAuthor = Console.ReadLine() ?? string.Empty;
            library.SearchByAuthor(searchAuthor);
        }

        static void RemoveItem(LibraryService library)
        {
            Console.Write("Enter title of item to remove: ");
            string title = Console.ReadLine() ?? string.Empty;
            library.RemoveItem(title);
        }
    }
}