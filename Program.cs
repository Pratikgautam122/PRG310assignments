using System;

namespace HelloWorld
{
    class Program
    {
        static void Main()
        {
            // Main entry point of the project.
            // Shows the project selection menu to the user.
            
            // Variable to store user's menu choice. Initially set to 0.
            int choice = 0;

            do // Start of do-while loop that keeps showing menu until user exits
            {
                // Display the main menu options
                Console.WriteLine("\n===== Project Selector =====");
                Console.WriteLine("1. Task Management System");
                Console.WriteLine("2. Simple Banking System");
                Console.WriteLine("3. Exit");
                Console.Write("Select a project: ");

                try
                {
                    // Read user input and convert to integer
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    // Handle invalid input that is not a number
                    Console.WriteLine("Invalid input! Enter a number.");
                    continue; // Loop back to menu without executing switch statement
                }

                // Switch case to select which project to run based on user choice
                switch (choice)
                {
                    case 1:
                        TaskManagementSystem.Run();  // Calls Task Management system
                        break;
                    case 2:
                        BankingSystem.Run();        // Calls Banking system
                        break;
                    case 3:
                        Console.WriteLine("Exiting application..."); // Exit message
                        break;
                    default:
                        Console.WriteLine("Invalid option! Choose 1-3."); // Invalid choice message
                        break;
                }

            } while (choice != 3); // Loop continues until user chooses option 3 (Exit)
        }
    }
}