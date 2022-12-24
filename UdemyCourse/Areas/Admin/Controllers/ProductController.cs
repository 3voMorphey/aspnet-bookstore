using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemyCourse.DataAccess.Repository.IRepository;
using UdemyCourse.Models;
using UdemyCourse.Models.ViewModels;

namespace UdemyCourse.Controllers;
[Area("Admin")]
public class ProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

  
    public IActionResult Index()
    {
        IEnumerable<Product> objProducts = _unitOfWork.Product.GetAll();
        return View(objProducts);
    }

   
    
    //GET
    public IActionResult Upsert(int? id)
    {
        ProductVM product = new ProductVM
        {
            Product = new Product(),
            CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
            CoverTypeList = _unitOfWork.CoverType.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
        };
           
        if (id == null || id == 0)
        {
            
            return View(product);
        }
        else
        {
            
        }

        
        return View(product);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Product obj,IFormFile file)
    {
        if (ModelState.IsValid)
        {
            
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        return View(obj);
    }

    //GET
   public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var coverFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);

        if (coverFromDb == null)
        {
            return NotFound();
        }
        return View(coverFromDb);
    }
    
    //POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var coverFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);

        if (coverFromDb == null)
        {
            return NotFound();
        }
            
        _unitOfWork.Product.Remove(coverFromDb);
        _unitOfWork.Save();
        TempData["success"] = "Product deleted successfully";
        return RedirectToAction("Index");
    }
}