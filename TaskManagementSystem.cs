using System;
using System.Collections.Generic;

namespace HelloWorld
{
    class TaskManagementSystem
    {
        // List to store all task objects. This is a dynamic list that can grow.
        static List<Task> tasks = new List<Task>();

        // Entry function to run the Task Management menu
        public static void Run()
        {
            // Variable to store user's menu choice. Initially set to 0.
            int choice = 0;

            do // Start of do-while loop that keeps showing menu until user returns to main menu
            {
                // Display task management menu options
                Console.WriteLine("\n--- Task Management System ---");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View All Tasks");
                Console.WriteLine("3. Mark Task as Complete");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Return to Main Menu");
                Console.Write("Select option: ");

                try
                {
                    // Read menu choice from user and convert to integer
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    // Handle invalid input that is not a number
                    Console.WriteLine("Invalid input! Enter a number.");
                    continue; // Loop back to menu without executing switch statement
                }

                // Call the appropriate function for each menu option based on user choice
                switch (choice)
                {
                    case 1: AddTask(); break;           // Call function to add new task
                    case 2: ViewTasks(); break;         // Call function to view all tasks
                    case 3: MarkTaskComplete(); break;  // Call function to mark task as complete
                    case 4: DeleteTask(); break;        // Call function to delete task
                    case 5: Console.WriteLine("Returning to Main Menu..."); break; // Return message
                    default: Console.WriteLine("Invalid option! Choose 1-5."); break; // Invalid choice
                }

            } while (choice != 5); // Loop until user chooses option 5 (Return to Main Menu)
        }

        // -------- TASK FUNCTIONS --------

        // Function to add a new task to the list
        static void AddTask()
        {
            // Create a new task object to store task information
            Task task = new Task();

            // Prompt user to enter task title and store in task object
            Console.Write("Enter task title: ");
            task.Title = Console.ReadLine() ?? ""; // Use empty string if input is null

            // Prompt user to enter task description and store in task object
            Console.Write("Enter task description: ");
            task.Description = Console.ReadLine() ?? ""; // Use empty string if input is null

            // Prompt user to enter task priority level and store in task object
            Console.Write("Enter priority (High/Medium/Low): ");
            task.Priority = Console.ReadLine() ?? ""; // Use empty string if input is null

            try
            {
                // Read due date input and convert to DateTime format
                Console.Write("Enter due date (yyyy-mm-dd): ");
                task.DueDate = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                // If invalid date format is entered, set due date to today's date
                Console.WriteLine("Invalid date! Setting due date to today.");
                task.DueDate = DateTime.Today;
            }

            // Initialize task as incomplete (not completed yet)
            task.IsCompleted = false;
            
            // Add the newly created task to the tasks list
            tasks.Add(task);
            
            Console.WriteLine("Task added successfully!"); // Success message
        }

        // Function to view all tasks in the list
        static void ViewTasks()
        {
            // Check if tasks list is empty
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available."); // Message if no tasks exist
                return; // Exit function if no tasks to display
            }

            // Loop through the task list and display each task with its details
            for (int i = 0; i < tasks.Count; i++)
            {
                // Display task number (i+1 because list index starts at 0)
                Console.WriteLine($"\nTask {i + 1}");
                
                // Display task title
                Console.WriteLine($"Title       : {tasks[i].Title}");
                
                // Display task description
                Console.WriteLine($"Description : {tasks[i].Description}");
                
                // Display task priority level
                Console.WriteLine($"Priority    : {tasks[i].Priority}");
                
                // Display task due date in short date format (MM/dd/yyyy)
                Console.WriteLine($"Due Date    : {tasks[i].DueDate.ToShortDateString()}");
                
                // Display task completion status (true or false)
                Console.WriteLine($"Completed   : {tasks[i].IsCompleted}");
            }
        }

        // Function to mark a task as complete
        static void MarkTaskComplete()
        {
            ViewTasks(); // First display all tasks so user can see task numbers
            
            // Prompt user to enter which task number to mark as complete
            Console.Write("Enter task number to mark complete: ");
            
            try
            {
                // Read task number and convert to list index (subtract 1 because list starts at 0)
                int index = Convert.ToInt32(Console.ReadLine()) - 1;
                
                // Check if entered index is valid (within list bounds)
                if (index >= 0 && index < tasks.Count)
                {
                    // Set IsCompleted property to true for selected task
                    tasks[index].IsCompleted = true;
                    Console.WriteLine("Task marked as complete!"); // Success message
                }
                else
                    Console.WriteLine("Invalid task number."); // Error if number out of range
            }
            catch
            {
                // Handle invalid input that is not a number
                Console.WriteLine("Invalid input! Enter a number.");
            }
        }

        // Function to delete a task from the list
        static void DeleteTask()
        {
            ViewTasks(); // First display all tasks so user can see task numbers
            
            // Prompt user to enter which task number to delete
            Console.Write("Enter task number to delete: ");
            
            try
            {
                // Read task number and convert to list index (subtract 1 because list starts at 0)
                int index = Convert.ToInt32(Console.ReadLine()) - 1;
                
                // Check if entered index is valid (within list bounds)
                if (index >= 0 && index < tasks.Count)
                {
                    // Remove task at specified index from the list
                    tasks.RemoveAt(index);
                    Console.WriteLine("Task deleted successfully!"); // Success message
                }
                else
                    Console.WriteLine("Invalid task number."); // Error if number out of range
            }
            catch
            {
                // Handle invalid input that is not a number
                Console.WriteLine("Invalid input! Enter a number.");
            }
        }
    }

    // -------- TASK MODEL --------
    // Task class that defines the structure of a task object
    class Task
    {
        public string Title { get; set; } = "";       // Task title/name
        public string Description { get; set; } = ""; // Detailed description of task
        public string Priority { get; set; } = "";    // Task priority level (High/Medium/Low)
        public DateTime DueDate { get; set; }         // Date when task is due
        public bool IsCompleted { get; set; }         // Task completion status (true/false)
    }
}