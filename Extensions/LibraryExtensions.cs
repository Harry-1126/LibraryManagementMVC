using LibraryManagementMVC.Models;

namespace LibraryManagementMVC.Extensions;

public static class LibraryExtensions
{
    public static string GetDueStatus(this LibraryMember member)
    {
        if (!member.ReturnDate.HasValue)
        {
            return "Issued";
        }

        if (member.ReturnDate.Value < DateTime.Today)
        {
            return "Overdue";
        }

        if ((member.ReturnDate.Value - DateTime.Today).TotalDays <= 3)
        {
            return "Due Soon";
        }

        return "Returned";
    }

    public static decimal CalculateFine(this LibraryMember member)
    {
        if (!member.ReturnDate.HasValue)
        {
            return 0;
        }

        if (member.ReturnDate.Value >= DateTime.Today)
        {
            return 0;
        }

        int overdueDays =
            (DateTime.Today - member.ReturnDate.Value).Days;

        return overdueDays * 10;
    }
}