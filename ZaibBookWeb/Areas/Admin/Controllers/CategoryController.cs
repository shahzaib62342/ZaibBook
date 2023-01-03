using Microsoft.AspNetCore.Mvc;
using ZaibBook.DataAccess.Infrastructure.IRepository;
using ZaibBook.Models.ViewModel;

namespace ZaibBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            CategoryVM vm=new CategoryVM();
            vm.categories = _unitOfWork.Category.GetAll();
            return View(vm);
        }

        //GET
        //public IActionResult Create()
        //{
        //    return View();
        //}

        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Category obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var isExist = _unitOfWork.Category.GetT(x => x.Name == obj.Name);
        //        if (isExist == null)
        //        {
        //            _unitOfWork.Category.Add(obj);
        //            _unitOfWork.Save();
        //            TempData["success"] = "Category Added Successfully";
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            TempData["error"] = "Name already exist in database";
        //            return View(obj);
        //        }

        //    }
        //    else
        //    {
        //        return View(obj);
        //    }

        //}

        //GET
        public IActionResult CreateUpdate(Guid? id)
        {
            //Used ViewModel for Tightly Coupled issue
            CategoryVM vm = new CategoryVM();
            if (!id.HasValue)
            {
                return View(vm);
            }
            else
            {
                var CaregoryFromDb = _unitOfWork.Category.GetT(x => x.ID == id);
                if (CaregoryFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(CaregoryFromDb);
                }
            }


 
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(CategoryVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj.Category);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
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
            var CaregoryFromDb = _unitOfWork.Category.GetT(x => x.ID == id);
            if (CaregoryFromDb == null)
            {
                return NotFound();
            }

            return View(CaregoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Guid? id)
        {
            var objCategory = _unitOfWork.Category.GetT(x => x.ID == id);
            if (objCategory == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Delete(objCategory);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Successfully";


            return RedirectToAction("Index");

        }
    }
}
