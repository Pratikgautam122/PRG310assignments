using System;

namespace LibraryManagementSystem.Model
{
    public class Book : Item
    {
        private string _author;

        public string Author
        {
            get { return _author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidItemDataException("Author cannot be null or empty.");
                }

                if (value.Length < 5)
                {
                    throw new InvalidItemDataException("Author name must be at least 5 characters long.");
                }

                if (!char.IsUpper(value[0]))
                {
                    throw new InvalidItemDataException("Author name must begin with a capital letter.");
                }

                _author = value;
            }
        }

        public Book(string title, string author, string publisher, int year)
        {
            Title = title;
            Publisher = publisher;
            PublicationYear = year;
            Author = author;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[BOOK] Title: {Title}, Author: {Author}, Publisher: {Publisher}, Year: {PublicationYear}");
        }
    }
}