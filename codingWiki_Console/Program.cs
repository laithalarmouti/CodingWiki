// See https://aka.ms/new-console-template for more information
using codingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

Console.WriteLine("Hello, World!");


//using (ApplicationDbContext context = new())
//{
//    context.Database.EnsureCreated();
//    if (context.Database.GetPendingMigrations().Count(0) > 0)
//    { 
//        context.Database.Migrate(); 
//    }
//}

getAllBooks();
//addBook();
getBook();

void getAllBooks()
{
    using var context = new ApplicationDbContext();
    var books = context.Books.ToList();
    foreach(var book in books)
    {
        Console.WriteLine(book.Title + "-" + book.ISBN);
    }
}



void addBook()
{
    Book book = new() {Title= "Ant Without Duty", ISBN= "48XQ2", Price= 44.22m, Publisher_Id= 4345 };
    using var context = new ApplicationDbContext();
    var books = context.Books.Add(book);
    context.SaveChanges();
   
}

void getBook()
{
    try
    {
        using var context = new ApplicationDbContext();
        var books = context.Books;
        //Console.WriteLine(book.Title + "-" + book.ISBN);
        foreach (var book in books)
        {
            Console.WriteLine(book.Title + "-" + book.ISBN);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    } 
}