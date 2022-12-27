using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using ZaibBook.DataAccess;
using ZaibBook.Models;

namespace ZaibBook.Controllers
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
            IEnumerable<Category> CategoriesList = _db.Categories;
            return View(CategoriesList);
        }
    
        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                var isExist = _db.Categories.FirstOrDefault(d => d.Name == obj.Name);
                if (isExist == null)
                {
                    _db.Categories.Add(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Category Added Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Name already exist in database";
                    return View(obj);
                }

            }
            else
            {
                return View(obj);
            }

        }

        //GET
        public IActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            var CaregoryFromDb = _db.Categories.Find(id);
            if (CaregoryFromDb == null)
            {
                return NotFound();
            }

                return View(CaregoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                var isExist = _db.Categories.FirstOrDefault(d => d.Name == obj.Name);
                if (isExist == null)
                {
                    _db.Categories.Update(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Category Updated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Name already exist in database";
                    return View(obj);
                }
            }
            else
            {
                return View(obj);
            }

        }


        //GET
        public IActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            var CaregoryFromDb = _db.Categories.Find(id);
            if (CaregoryFromDb == null)
            {
                return NotFound();
            }

            return View(CaregoryFromDb);
        }

        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Guid ? id)
        {
            var objCategory= _db.Categories.Find(id);
            if (objCategory == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(objCategory);
                _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";


            return RedirectToAction("Index");

        }
    }
}
