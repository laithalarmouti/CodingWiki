using codingWiki_DataAccess.Data;
using codingWiki_Model.ViewModels;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Book> objList = _db.Books.ToList();
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

            if (obj == null || id==0)
            {
                return View(obj);
            }
            obj.Book = _db.Books.FirstOrDefault(c=> c.BookID == id);
            if (obj == null) 
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Book obj) 
        {
            if (ModelState.IsValid)
            {
                if(obj.BookID == 0)
                {
                    await _db.Books.AddAsync(obj);
                }
                else
                {
                    _db.Books.Update(obj);
                }
                await _db.SaveChangesAsync();
            }
            return View(obj);
        }

        //public IActionResult Upsert(int? id)
        //{
        //    Category obj = new();
        //    if (id ==null || id==0)
        //    {
        //        return View(obj);
        //    }
        //    //.....Edit
        //    obj= _db.Categories.FirstOrDefault(u => u.CategoryID==id);
        //    if (obj==null) 
        //    { 
        //        return NotFound(); 
        //    }
        //    return View(obj);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Upsert(Category obj)
        //{
        //    if (ModelState.IsValid)
        //    {     //.....Create
        //        if(obj.CategoryID==0)
        //        {
        //            await _db.Categories.AddAsync(obj);
        //        }//........Update
        //        else
        //        {
        //             _db.Categories.Update(obj);
        //        }
        //        await _db.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(obj);
        //}

        //public async Task<IActionResult> Delete(int id)
        //{
        //    Category obj = new();

        //    //.....Delete
        //    obj = _db.Categories.FirstOrDefault(u => u.CategoryID == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Categories.Remove(obj);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));

        //}





    }
}
