using CRUDWeb.Data;
using CRUDWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWeb.Controllers
{
    public class ListController : Controller
    {
        private readonly WebAppDbContext _db;

        public ListController(WebAppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<List> objCategoryList = _db.Lists.ToList();
            return View(objCategoryList);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(List obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The name and description can't match.");
            }
            if(ModelState.IsValid)
            {
                _db.Lists.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj); 
            
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) 
            { 
                return NotFound();
            }
            var listFromDb = _db.Lists.Find(id);
            if (listFromDb == null)
            {
                return NotFound();
            }
            return View(listFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(List obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The name and description can't match.");
            }
            if (ModelState.IsValid)
            {
                _db.Lists.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var listFromDb = _db.Lists.Find(id);
            if (listFromDb == null)
            {
                return NotFound();
            }
            return View(listFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete_(int? id)
        {
            var obj = _db.Lists.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Lists.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

    }
}

