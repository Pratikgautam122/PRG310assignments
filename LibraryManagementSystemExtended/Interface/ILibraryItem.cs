namespace LibraryManagementSystemExtended.Interface
{
    // Interface defining contract for all library items
    public interface ILibraryItem
    {
        string Title { get; set; }
        string Publisher { get; set; }
        int PublicationYear { get; set; }
        void DisplayInfo();
        string ToFileString();
    }
}