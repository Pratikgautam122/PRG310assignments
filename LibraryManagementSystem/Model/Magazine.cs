using System;

namespace LibraryManagementSystem.Model
{
    public class Magazine : Item
    {
        private int _issueNumber;

        public int IssueNumber
        {
            get { return _issueNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidItemDataException("Issue number must be a positive number.");
                }

                _issueNumber = value;
            }
        }

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
    }
}