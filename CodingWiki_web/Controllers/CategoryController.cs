using codingWiki_DataAccess.Data;
using codingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objList = _db.Categories.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Category obj = new();
            if (id == null || id == 0)
            {
                return View(obj);
            }
            //.....Edit
            obj = _db.Categories.FirstOrDefault(u => u.CategoryID == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category obj)
        {
            if (ModelState.IsValid)
            {     //.....Create
                if (obj.CategoryID == 0)
                {
                    await _db.Categories.AddAsync(obj);
                }//........Update
                else
                {
                    _db.Categories.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category obj = new();

            //.....Delete
            obj = _db.Categories.FirstOrDefault(u => u.CategoryID == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        public IActionResult CreateMultiple2()
        {
            List<Category> categories = new();
            for (int i = 1; i <= 2; i++)
            {
                categories.Add(new Category { CategoryName = Guid.NewGuid().ToString() });

            }
            _db.AddRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple5()
        {
            List<Category> categories = new();
            for (int i = 1; i <= 5; i++)
            {
                categories.Add(new Category { CategoryName = Guid.NewGuid().ToString() });

            }
            _db.AddRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            List<Category> categories = _db.Categories.OrderByDescending(c => c.CategoryID).Take(2).ToList();
            _db.RemoveRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple5()
        {
            List<Category> categories = _db.Categories.OrderByDescending(c => c.CategoryID).Take(5).ToList();
            _db.RemoveRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
