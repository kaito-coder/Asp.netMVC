using BullyBookWeb.Data;
using BullyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BullyBookWeb.Controllers
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
            IEnumerable<Category> objCategoryList = _db.Categories;
           
            return View(objCategoryList);
        }
        //GEt
        public IActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GEt
        public IActionResult Edit(int? ID)
        {
            if(ID == null || ID == 0)
            {
                return NotFound();
            }
            var categoryFromFb = _db.Categories.Find(ID);
            if(categoryFromFb == null)
            {
                return NotFound();
            }
            return View(categoryFromFb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GEt
        public IActionResult Delete(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var categoryFromFb = _db.Categories.Find(ID);
            if (categoryFromFb == null)
            {
                return NotFound();
            }
            return View(categoryFromFb);
        }
        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? ID)
        {
            var obj = _db.Categories.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}
