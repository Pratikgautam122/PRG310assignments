using System;

namespace LibraryManagementSystemExtended.Model
{
    public class Newspaper : LibraryItemBase
    {
        private string _editor;

        // Editor - min 5 chars, must start with capital
        public string Editor
        {
            get { return _editor; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Editor cannot be null or empty.");
                if (value.Length < 5)
                    throw new InvalidItemDataException("Editor name must be at least 5 characters long.");
                if (!char.IsUpper(value[0]))
                    throw new InvalidItemDataException("Editor name must begin with a capital letter.");
                _editor = value;
            }
        }

        public Newspaper() { }

        public Newspaper(string title, string editor, string publisher, int year)
        {
            Title = title;
            Publisher = publisher;
            PublicationYear = year;
            Editor = editor;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[NEWSPAPER] Title: {Title}, Editor: {Editor}, Publisher: {Publisher}, Year: {PublicationYear}");
        }

        // Format: NEWSPAPER|Title|Editor|Publisher|Year
        public override string ToFileString()
        {
            return $"NEWSPAPER|{Title}|{Editor}|{Publisher}|{PublicationYear}";
        }

        // Deserialize from file string
        public static Newspaper FromFileString(string line)
        {
            string[] parts = line.Split('|');
            return new Newspaper(parts[1], parts[2], parts[3], int.Parse(parts[4]));
        }
    }
}