using codingWiki_DataAccess.Data;
using codingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Author> objList = _db.Authors.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Author obj = new();
            if (id == null || id == 0)
            {
                return View(obj);
            }
            //.....Edit
            obj = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Author obj)
        {
            if (ModelState.IsValid)
            {     //.....Create
                if (obj.Author_Id == 0)
                {
                    await _db.Authors.AddAsync(obj);
                }//........Update
                else
                {
                    _db.Authors.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Author obj = new();

            //.....Delete
            obj = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Authors.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }


    }
}
