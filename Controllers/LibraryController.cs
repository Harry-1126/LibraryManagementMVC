using LibraryManagementMVC.Models;
using LibraryManagementMVC.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementMVC.Controllers;

public class LibraryController : Controller
{
    private static List<Book> books = new List<Book>
    {
        new Book
        {
            BookId = 1,
            Title = "C# Programming",
            Author = "John Smith",
            Category = "Programming",
            Price = 500,
            AvailableCopies = 5
        },

        new Book
        {
            BookId = 2,
            Title = "ASP.NET Core",
            Author = "David Miller",
            Category = "Web Development",
            Price = 650,
            AvailableCopies = 3
        },

        new Book
        {
            BookId = 3,
            Title = "Database Management",
            Author = "Robert Brown",
            Category = "Database",
            Price = 450,
            AvailableCopies = 4
        }
    };

    private static List<LibraryMember> issuedBooks = new List<LibraryMember>();


    public IActionResult Index()
    {
        return View(issuedBooks);
    }


    [HttpGet]
    public IActionResult IssueBook()
    {
        return View();
    }


    [HttpPost]
    public IActionResult IssueBook(LibraryMember member)
    {
        if (!ModelState.IsValid)
        {
            return View(member);
        }

        member.MemberId = issuedBooks.Count + 1;

        issuedBooks.Add(member);

        return RedirectToAction("Index");
    }


    public IActionResult BookDetails(int id)
    {
        var member = issuedBooks.FirstOrDefault(x => x.MemberId == id);

        if (member == null)
        {
            return NotFound();
        }

        return View(member);
    }


    public IActionResult About()
    {
        return View();
    }
}