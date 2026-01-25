using System;

namespace LibraryManagementSystem
{
    public class InvalidItemDataException : Exception
    {
        public InvalidItemDataException(string message) : base(message)
        {
        }
    }
}