namespace LibraryManagementMVC.Models;

public class LibraryMember
{
    public int MemberId { get; set; }

    public string MemberName { get; set; } = "";

    public string Department { get; set; } = "";

    public string Email { get; set; } = "";

    public int BookId { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime? ReturnDate { get; set; }
}