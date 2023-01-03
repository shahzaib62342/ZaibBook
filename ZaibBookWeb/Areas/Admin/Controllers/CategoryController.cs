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
            CategoryVM vm = new CategoryVM();
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
                vm.Category = _unitOfWork.Category.GetT(x => x.ID == id);
                if (vm.Category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }



        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(CategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Category.ID == Guid.Empty)
                {

                    _unitOfWork.Category.Add(vm.Category);
                    TempData["success"] = "Category Added Successfully";

                }
                else
                {
                    _unitOfWork.Category.Update(vm.Category);
                    TempData["success"] = "Category Updated Successfully";

                }
                _unitOfWork.Save();
                return RedirectToAction("Index");

            }
            else
            {
                return View(vm);
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
