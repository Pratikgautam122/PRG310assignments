using System;
using LibraryManagementSystemExtended.Interface;

namespace LibraryManagementSystemExtended.Model
{
    // Base class for all library items with common validation
    public abstract class LibraryItemBase : ILibraryItem
    {
        private string _title;
        private string _publisher;
        private int _publicationYear;

        // Title - min 5 chars, must start with capital
        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Title cannot be null or empty.");
                if (value.Length < 5)
                    throw new InvalidItemDataException("Title must be at least 5 characters long.");
                if (!char.IsUpper(value[0]))
                    throw new InvalidItemDataException("Title must begin with a capital letter.");
                _title = value;
            }
        }

        // Publisher - min 6 chars, must start with capital
        public string Publisher
        {
            get { return _publisher; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Publisher cannot be null or empty.");
                if (value.Length < 6)
                    throw new InvalidItemDataException("Publisher must be at least 6 characters long.");
                if (!char.IsUpper(value[0]))
                    throw new InvalidItemDataException("Publisher must begin with a capital letter.");
                _publisher = value;
            }
        }

        // Publication year - must be 4-digit number
        public int PublicationYear
        {
            get { return _publicationYear; }
            set
            {
                if (value < 1000 || value > 9999)
                    throw new InvalidItemDataException("Publication Year must be a 4-digit number.");
                _publicationYear = value;
            }
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}, Publisher: {Publisher}, Year: {PublicationYear}");
        }

        // Derived classes implement file serialization
        public abstract string ToFileString();
    }
}