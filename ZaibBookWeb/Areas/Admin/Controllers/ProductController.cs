using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaibBook.DataAccess.Infrastructure.IRepository;
using ZaibBook.Models.ViewModel;

namespace ZaibBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        //Interface Injecting DI Like IUnitOfWork . it is used to take access to reache wwwroot folder
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {

            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult Index()
        {
            ProductVM vm = new ProductVM();
            vm.Products = _unitOfWork.Product.GetAll();
            return View(vm);
        }

        //GET
        public IActionResult CreateUpdate(Guid? id)
        {
            //Used ViewModel for Tightly Coupled issue
            ProductVM vm = new ProductVM()
            {
                Product = new(),
                //CategoriesList for Dropdown in Product
                Categories = _unitOfWork.Category.GetAll().Select(x =>new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.ID.ToString(),
                    }
                ),
                //WritersList for Dropdown in Product
                Writers = _unitOfWork.Writer.GetAll().Select(x =>

                    new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id.ToString(),
                    }
                )
            };
            if (!id.HasValue)
            {
                return View(vm);
            }
            else
            {
                vm.Product = _unitOfWork.Product.GetT(x => x.Id == id);
                if (vm.Product == null)
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
        public IActionResult CreateUpdate(ProductVM vm,IFormFile? file)
        {
            
            if (ModelState.IsValid)
            {
                string fileName = String.Empty;
                if(file !=null)
                {

                    //System.IO.Path.Combine() use to combine to Paths and return string
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImages");

                    //System.Guid.NewGuid() use to generate New Guid and concate with fileName
                    fileName = Guid.NewGuid().ToString() + "-" + file.FileName;

                    //use to combine uploadDir with fileName and returning filePath string
                    string filePath = Path.Combine(uploadDir, fileName);

                    using (var fileStream=new FileStream(filePath,FileMode.Create))
                    {
                        //Coping file to final location
                        file.CopyTo(fileStream);
                    }
                    //Assigning Path to Product ImageUrl
                    vm.Product.ImageUrl = @"\ProductImages\" + filePath;
                }

                if (vm.Product.Id == Guid.Empty)
                {
                    _unitOfWork.Product.Add(vm.Product);
                    TempData["success"] = "Product Added Successfully";
                }
                else
                {
                    _unitOfWork.Product.Update(vm.Product);
                    TempData["success"] = "Product Updated Successfully";

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
            var ProductFromDb = _unitOfWork.Product.GetT(x => x.Id == id);
            if (ProductFromDb == null)
            {
                return NotFound();
            }

            return View(ProductFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Guid? id)
        {
            var objProduct = _unitOfWork.Product.GetT(x => x.Id == id);
            if (objProduct == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Delete(objProduct);
            _unitOfWork.Save();
            TempData["success"] = "Product Deleted Successfully";


            return RedirectToAction("Index");

        }
    }
}
