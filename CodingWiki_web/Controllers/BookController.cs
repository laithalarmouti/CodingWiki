using codingWiki_DataAccess.Data;
using codingWiki_Model.Models;
using codingWiki_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_web.Controllers
{
    public class BookController(ApplicationDbContext _db) : Controller
    {
        public IActionResult Index()
        {
            List<Book> objList = _db.Books.Include(u => u.Publisher).ToList();

            //foreach(var obj in objList)
            //{
            //    //obj.Publisher = _db.Publishers.Find(obj.Publisher_Id);
            //    _db.Entry(obj).Reference(u=>u.Publisher).Load();
            //}
            return View(objList);
        }
        public IActionResult Upsert(int? id)
        {
            BookVM obj = new();
            obj.PublisherList = _db.Publishers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            });

            if (obj == null || id == 0)
            {
                return View(obj);
            }
            obj.Book = _db.Books.FirstOrDefault(c => c.BookID == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM obj)
        {

            if (obj.Book.BookID == 0)
            {
                await _db.Books.AddAsync(obj.Book);
            }
            else
            {
                _db.Books.Update(obj.Book);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            BookDetail obj = new();



            obj = _db.BookDetails.Include(u => u.Book).FirstOrDefault(u => u.Book_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(BookDetail obj)
        {

            if (obj.BookDetail_Id == 0)
            {
                await _db.BookDetails.AddAsync(obj);
            }
            else
            {
                _db.BookDetails.Update(obj);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int id)
        {
            Book obj = new();

            //.....Delete
            obj = _db.Books.FirstOrDefault(u => u.BookID == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Books.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult ManageAuthors(int id)
        {


            BookAuthorVM obj = new()
            {
                BookAuthorList = _db.BookAuthorMaps
                .Where(u => u.Book_Id == id)
                .Include(u => u.Author)
                .ToList(),

                BookAuthor = new()
                {
                    Book_Id = id
                },

                Book = _db.Books.FirstOrDefault(u => u.BookID == id)

            };
            List<int> tempListOfAssignedAuthor = obj.BookAuthorList.Select(u => u.Author_Id).ToList();
            //NOT IN CLAUSE
            var tempList = _db.Authors.Where(u => !tempListOfAssignedAuthor.Contains(u.Author_Id)).ToList();
            obj.AuthorList = tempList.Select(i => new SelectListItem
            { 
                Text = i.FullName,
                Value = i.Author_Id.ToString()
            });
            
            
            
            
            return View(obj); // You need to return a view or some other ActionResult
        }
        public async Task<IActionResult> Playground()
        {
            IEnumerable<Book> BookList1 = _db.Books;
            var FilterBook1 = BookList1.Where(b => b.Price > 250).ToList();

            IQueryable<Book> BookList2 = _db.Books;
            var FilterBook2 = BookList2.Where(b => b.Price > 250).ToList();
            //var bookTemp = _db.Books.FirstOrDefault();
            //bookTemp.Price = 100;

            //var bookCollection = _db.Books;
            //decimal totalPrice = 0;

            //foreach (var book in bookCollection)
            //{
            //    totalPrice += book.Price;
            //}

            //var bookList = _db.Books.ToList();
            //foreach (var book in bookList)
            //{
            //    totalPrice += book.Price;
            //}

            //var bookCollection2 = _db.Books;
            //var bookCount1 = bookCollection2.Count();

            //var bookCount2 = _db.Books.Count();
            return RedirectToAction(nameof(Index));

        }
    }
}
