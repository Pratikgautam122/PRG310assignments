using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LibraryManagementSystemExtended.Interface;
using LibraryManagementSystemExtended.Model;

namespace LibraryManagementSystemExtended.Service
{
    // Manages library operations: add, remove, search, sort, and file persistence
    public class LibraryService
    {
        private List<ILibraryItem> _items = new List<ILibraryItem>();
        private readonly string _filePath = "libraryData.txt";

        public LibraryService()
        {
            LoadFromFile();
        }

        // Add item after checking for duplicates
        public void AddItem(ILibraryItem item)
        {
            CheckForDuplicate(item);
            _items.Add(item);
            SaveToFile();
            Console.WriteLine($"Item added successfully: Title: {item.Title} - Publisher: {item.Publisher} - Year: {item.PublicationYear}");
        }

        // Throw exception if duplicate exists
        private void CheckForDuplicate(ILibraryItem newItem)
        {
            foreach (var existingItem in _items)
            {
                if (IsDuplicate(existingItem, newItem))
                    throw new DuplicateItemException("Item already exists in the library.");
            }
        }

        // Compare items based on type and properties
        private bool IsDuplicate(ILibraryItem existingItem, ILibraryItem newItem)
        {
            if (existingItem.GetType() != newItem.GetType())
                return false;

            if (existingItem.Title != newItem.Title ||
                existingItem.Publisher != newItem.Publisher ||
                existingItem.PublicationYear != newItem.PublicationYear)
                return false;

            // Check type-specific properties
            if (existingItem is Book existingBook && newItem is Book newBook)
                return existingBook.Author == newBook.Author;

            if (existingItem is Magazine existingMagazine && newItem is Magazine newMagazine)
                return existingMagazine.IssueNumber == newMagazine.IssueNumber;

            if (existingItem is Newspaper existingNewspaper && newItem is Newspaper newNewspaper)
                return existingNewspaper.Editor == newNewspaper.Editor;

            return false;
        }

        public void DisplayAllItems()
        {
            Console.WriteLine("\n========== All Library Items ==========");
            if (_items.Count == 0)
            {
                Console.WriteLine("No items in the library.");
            }
            else
            {
                foreach (var item in _items)
                    item.DisplayInfo();
            }
            Console.WriteLine("=======================================\n");
        }

        // Case-insensitive partial match search
        public void SearchByTitle(string searchTitle)
        {
            var results = _items.Where(item => item.Title.ToLower().Contains(searchTitle.ToLower())).ToList();
            Console.WriteLine($"\n========== Search Results for '{searchTitle}' ==========");
            if (results.Count == 0)
            {
                Console.WriteLine("No items found.");
            }
            else
            {
                foreach (var item in results)
                    item.DisplayInfo();
            }
            Console.WriteLine("=====================================================\n");
        }

        // Search books only by author name
        public void SearchByAuthor(string searchAuthor)
        {
            var results = _items.OfType<Book>().Where(book => book.Author.ToLower().Contains(searchAuthor.ToLower())).ToList();
            Console.WriteLine($"\n========== Search Results for Author '{searchAuthor}' ==========");
            if (results.Count == 0)
            {
                Console.WriteLine("No books found with that author.");
            }
            else
            {
                foreach (var book in results)
                    book.DisplayInfo();
            }
            Console.WriteLine("=============================================================\n");
        }

        // Sort and display by title alphabetically
        public void SortByTitle()
        {
            var sortedItems = _items.OrderBy(item => item.Title).ToList();
            Console.WriteLine("\n========== Items Sorted by Title ==========");
            foreach (var item in sortedItems)
                item.DisplayInfo();
            Console.WriteLine("============================================\n");
        }

        // Sort and display by publication year
        public void SortByYear()
        {
            var sortedItems = _items.OrderBy(item => item.PublicationYear).ToList();
            Console.WriteLine("\n========== Items Sorted by Year ==========");
            foreach (var item in sortedItems)
                item.DisplayInfo();
            Console.WriteLine("===========================================\n");
        }

        // Remove item by title (case-insensitive)
        public void RemoveItem(string title)
        {
            var itemToRemove = _items.FirstOrDefault(item => item.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
                SaveToFile();
                Console.WriteLine($"Item '{title}' removed successfully.");
            }
            else
            {
                Console.WriteLine($"Item '{title}' not found.");
            }
        }

        // Save all items to file
        private void SaveToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    foreach (var item in _items)
                        writer.WriteLine(item.ToFileString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        // Load items from file on startup
        private void LoadFromFile()
        {
            if (!File.Exists(_filePath))
                return;

            try
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("BOOK"))
                            _items.Add(Book.FromFileString(line));
                        else if (line.StartsWith("MAGAZINE"))
                            _items.Add(Magazine.FromFileString(line));
                        else if (line.StartsWith("NEWSPAPER"))
                            _items.Add(Newspaper.FromFileString(line));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from file: {ex.Message}");
            }
        }
    }
}