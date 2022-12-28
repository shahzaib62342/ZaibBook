using Microsoft.AspNetCore.Mvc;
using ZaibBook.DataAccess.Infrastructure.IRepository;
using ZaibBook.DataAccess.Infrastructure.Repository;
using ZaibBook.Models;

namespace ZaibBookWeb.Controllers
{
    public class WriterController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public WriterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Writer> writerList = _unitOfWork.Writer.GetAll();
            return View(writerList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Writer writer)
        {
            if (ModelState.IsValid)
            {
                var isExist = _unitOfWork.Writer.GetT(x => x.Name == writer.Name);
                if (isExist == null)
                {
                    _unitOfWork.Writer.Add(writer);
                    _unitOfWork.Save();
                    TempData["success"] = "Writer Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Name already found in database";
                    return View(writer);
                }
            }
            else
            {
                return View(writer);
            }
        }

        //GET
        public IActionResult Edit(Guid? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Writer writer)
        {
            if (ModelState.IsValid)
            {
                var isExist = _unitOfWork.Writer.GetT(x => x.Name == writer.Name);
                if (isExist == null)
                {
                    _unitOfWork.Writer.Update(writer);
                    _unitOfWork.Save();
                    TempData["success"] = "Writer Updated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Name already found in database";
                    return View(writer);
                }
            }
            else
            {
                return View(writer);
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
