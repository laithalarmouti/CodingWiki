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

//getAllBooks();
//addBook();
//getBook();
//updateBook();
//deleteBook();


//async void getAllBooks()
//{
//    using var context = new ApplicationDbContext();
//    var books = await context.Books.ToListAsync();
//    foreach(var book in books)
//    {
//        Console.WriteLine(book.Title + "-" + book.ISBN);
//    }
//}



//async void addBook()
//{
//    Book book = new() {Title= "New Ef Core Book", ISBN= "99999", Price= 14.22m, Publisher_Id= 2455 };
//    using var context = new ApplicationDbContext();
//    var books = await context.Books.AddAsync(book);
//    await context.SaveChangesAsync();
   
//}

//async void getBook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var books = await context.Books.Skip(0).Take(2).ToListAsync();
//        //Console.WriteLine(book.Title + "-" + book.ISBN);
//        foreach (var book in books)
//        {
//            Console.WriteLine(book.Title + "-" + book.ISBN);
//        }

//        books = await context.Books.Skip(4).Take(1).ToListAsync();
//        foreach (var book in books)
//        {
//            Console.WriteLine(book.Title + " - " + book.ISBN);
//        }
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    } 
//}

//async void updateBook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var books = await context.Books.Where(u=> u.Publisher_Id==1).ToListAsync();
//        foreach (var book in books)
//        {
//            book.Price = 55.55m;
//        }
//        await context.SaveChangesAsync();  
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}

//async void deleteBook()
//{
//    using var context = new ApplicationDbContext();
//    var books = await context.Books.FindAsync(10);
//    context.Books.Remove(books);
//    await context.SaveChangesAsync() ; 
//}