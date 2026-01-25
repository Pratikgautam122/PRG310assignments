using System;
using System.Collections.Generic;
using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Service
{
    public class LibraryService
    {
        private List<Item> _items = new List<Item>();

        public void AddItem(Item item)
        {
            foreach (var existingItem in _items)
            {
                if (existingItem.Title == item.Title &&
                    existingItem.Publisher == item.Publisher &&
                    existingItem.PublicationYear == item.PublicationYear)
                {
                    throw new DuplicateItemException("Item already exists in the library.");
                }
            }

            _items.Add(item);
            Console.WriteLine($"Item added successfully: Title: {item.Title} - Publisher: {item.Publisher} - Year: {item.PublicationYear}");
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
                {
                    item.DisplayInfo();
                }
            }
            Console.WriteLine("=======================================\n");
        }
    }
}