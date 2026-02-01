using System;

namespace LibraryManagementSystemExtended
{
    // Exception thrown when attempting to add duplicate items
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException(string message) : base(message) { }
    }
}