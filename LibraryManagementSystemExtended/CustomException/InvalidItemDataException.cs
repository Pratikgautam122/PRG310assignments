using System;

namespace LibraryManagementSystemExtended
{
    // Exception thrown when item data fails validation
    public class InvalidItemDataException : Exception
    {
        public InvalidItemDataException(string message) : base(message) { }
    }
}