using System;

namespace LibraryManagementSystemExtended.Model
{
    public class Magazine : LibraryItemBase
    {
        private int _issueNumber;

        // Issue number - must be positive
        public int IssueNumber
        {
            get { return _issueNumber; }
            set
            {
                if (value <= 0)
                    throw new InvalidItemDataException("Issue number must be a positive number.");
                _issueNumber = value;
            }
        }

        public Magazine() { }

        public Magazine(string title, string publisher, int year, int issueNumber)
        {
            Title = title;
            Publisher = publisher;
            PublicationYear = year;
            IssueNumber = issueNumber;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[MAGAZINE] Title: {Title}, Issue #: {IssueNumber}, Publisher: {Publisher}, Year: {PublicationYear}");
        }

        // Format: MAGAZINE|Title|IssueNumber|Publisher|Year
        public override string ToFileString()
        {
            return $"MAGAZINE|{Title}|{IssueNumber}|{Publisher}|{PublicationYear}";
        }

        // Deserialize from file string
        public static Magazine FromFileString(string line)
        {
            string[] parts = line.Split('|');
            return new Magazine(parts[1], parts[3], int.Parse(parts[4]), int.Parse(parts[2]));
        }
    }
}