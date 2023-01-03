using Microsoft.AspNetCore.Mvc;
using ZaibBook.DataAccess.Infrastructure.IRepository;
using ZaibBook.DataAccess.Infrastructure.Repository;
using ZaibBook.Models;
using ZaibBook.Models.ViewModel;

namespace ZaibBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public WriterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            WriterVM vm=new WriterVM();
             vm.Writers = _unitOfWork.Writer.GetAll();
            return View(vm);
        }

        ////GET
        //public IActionResult Create()
        //{
        //    return View();
        //}

        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Writer writer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var isExist = _unitOfWork.Writer.GetT(x => x.Name == writer.Name);
        //        if (isExist == null)
        //        {
        //            _unitOfWork.Writer.Add(writer);
        //            _unitOfWork.Save();
        //            TempData["success"] = "Writer Created Successfully";
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            TempData["error"] = "Name already found in database";
        //            return View(writer);
        //        }
        //    }
        //    else
        //    {
        //        return View(writer);
        //    }
        //}

        //GET
        public IActionResult CreateUpdate(Guid? id)
        {
            WriterVM vm = new WriterVM();
            if (!id.HasValue)
            {
                return View(vm);
            }
            else
            {
                vm.Writer = _unitOfWork.Writer.GetT(x => x.Id == id);
                if (vm.Writer == null)
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
        public IActionResult CreateUpdate(WriterVM vm)
        {
            if (ModelState.IsValid)
            {   
                if(vm.Writer.Id == Guid.Empty) {
                    _unitOfWork.Writer.Add(vm.Writer);
                    TempData["success"] = "Writer Created Successfully";

                }
                else
                {
                    _unitOfWork.Writer.Update(vm.Writer);
                    TempData["success"] = "Writer Updated Successfully";
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
            var data = _unitOfWork.Writer.GetT(x => x.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Guid? id)
        {

            var result = _unitOfWork.Writer.GetT(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.Writer.Delete(result);
            _unitOfWork.Save();
            TempData["success"] = "Writer Deleted Successfully";
            return RedirectToAction("Index");
        }
    }

}
