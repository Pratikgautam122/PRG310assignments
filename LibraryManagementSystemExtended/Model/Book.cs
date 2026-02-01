using System;

namespace LibraryManagementSystemExtended.Model
{
    public class Book : LibraryItemBase
    {
        private string _author;

        // Author - min 5 chars, must start with capital
        public string Author
        {
            get { return _author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Author cannot be null or empty.");
                if (value.Length < 5)
                    throw new InvalidItemDataException("Author name must be at least 5 characters long.");
                if (!char.IsUpper(value[0]))
                    throw new InvalidItemDataException("Author name must begin with a capital letter.");
                _author = value;
            }
        }

        public Book() { }

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

        // Format: BOOK|Title|Author|Publisher|Year
        public override string ToFileString()
        {
            return $"BOOK|{Title}|{Author}|{Publisher}|{PublicationYear}";
        }

        // Deserialize from file string
        public static Book FromFileString(string line)
        {
            string[] parts = line.Split('|');
            return new Book(parts[1], parts[2], parts[3], int.Parse(parts[4]));
        }
    }
}