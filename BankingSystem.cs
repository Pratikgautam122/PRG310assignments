using System;

namespace HelloWorld
{
    class BankingSystem
    {
        // Static variable to store current account balance. Initially set to 0.0
        static double balance = 0;
        
        // Hardcoded PIN for login verification
        static string correctPin = "1234";

        // Entry function to run the banking system menu
        public static void Run()
        {
            // Call Login function and check if login was successful
            if (!Login())
            {
                // Exit system if login fails after 3 attempts
                Console.WriteLine("Account locked. Returning to Main Menu...");
                return; // Exit the banking system
            }

            // Variable to store user's menu choice. Initially set to 0.
            int choice = 0;

            do // Start of do-while loop that keeps showing menu until user exits
            {
                // Display banking menu options
                Console.WriteLine("\n--- Simple Banking System ---");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Balance Inquiry");
                Console.WriteLine("4. Exit to Main Menu");
                Console.Write("Choose an option: ");

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

                // Call functions for each banking operation based on user choice
                switch (choice)
                {
                    case 1: Deposit(); break;           // Call deposit function
                    case 2: Withdraw(); break;          // Call withdraw function
                    case 3: CheckBalance(); break;      // Call balance inquiry function
                    case 4: Console.WriteLine("Exiting Banking System..."); break; // Exit message
                    default: Console.WriteLine("Invalid option! Choose 1-4."); break; // Invalid choice
                }

            } while (choice != 4); // Loop until user chooses option 4 (Exit)
        }

        // -------- BANKING FUNCTIONS --------

        // Function for login with 3 attempts
        static bool Login()
        {
            // Variable to track number of login attempts remaining. Initially set to 3.
            int attempts = 3;

            // While loop continues as long as attempts remaining is greater than 0
            while (attempts > 0)
            {
                // Prompt user to enter PIN
                Console.Write("Enter PIN: ");
                string inputPin = Console.ReadLine(); // Read PIN input from user

                // Check if entered PIN matches the correct PIN
                if (inputPin == correctPin)
                {
                    // If PIN is correct, print success message
                    Console.WriteLine("Login successful!");
                    return true; // Return true to indicate successful login
                }
                else
                {
                    // If PIN is incorrect, decrement attempts by 1
                    attempts--;
                    // Display incorrect PIN message with remaining attempts
                    Console.WriteLine($"Incorrect PIN. Attempts left: {attempts}");
                }
            }

            return false; // Return false if all 3 login attempts fail
        }

        // Deposit function to add money to account
        static void Deposit()
        {
            // Prompt user to enter deposit amount
            Console.Write("Enter deposit amount: ");
            
            // Try to parse input as double and check if amount is positive
            if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
            {
                balance += amount; // Add deposit amount to current balance
                // Display success message with new balance formatted as currency
                Console.WriteLine($"Deposit successful. Balance: {balance:C}");
            }
            else
            {
                // Display error message if amount is invalid or negative
                Console.WriteLine("Invalid amount! Must be positive.");
            }
        }

        // Withdraw function to remove money from account
        static void Withdraw()
        {
            // Prompt user to enter withdrawal amount
            Console.Write("Enter withdrawal amount: ");
            
            // Try to parse input as double and check if amount is positive
            if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
            {
                // Check if withdrawal amount is less than or equal to current balance
                if (amount <= balance)
                {
                    balance -= amount; // Subtract withdrawal amount from balance
                    // Display success message with remaining balance
                    Console.WriteLine($"Withdrawal successful. Remaining balance: {balance:C}");
                }
                else
                {
                    // Display error message if balance is insufficient
                    Console.WriteLine("Error: Insufficient balance.");
                }
            }
            else
            {
                // Display error message if amount is invalid or negative
                Console.WriteLine("Invalid amount! Must be positive.");
            }
        }

        // Function to display current account balance
        static void CheckBalance()
        {
            // Print current balance formatted as currency
            Console.WriteLine($"Current balance: {balance:C}");
        }
    }
}