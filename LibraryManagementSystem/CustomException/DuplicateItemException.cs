using System;

namespace LibraryManagementSystem
{
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException(string message) : base(message)
        {
        }
    }
}