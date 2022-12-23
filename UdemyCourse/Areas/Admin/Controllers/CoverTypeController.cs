using Microsoft.AspNetCore.Mvc;
using UdemyCourse.DataAccess.Repository.IRepository;
using UdemyCourse.Models;

namespace UdemyCourse.Controllers;
[Area("Admin")]
public class CoverTypeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CoverTypeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

  
    public IActionResult Index()
    {
        IEnumerable<CoverType> objCoverTypes = _unitOfWork.CoverType.GetAll();
        return View(objCoverTypes);
    }

    //GET
    public IActionResult Create()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CoverType obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType created successfully";
            return RedirectToAction("Index");
        }

        return View(obj);
    }
    
    //GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var coverFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

        if (coverFromDb == null)
        {
            return NotFound();
        }
        return View(coverFromDb);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CoverType obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Update(obj);
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

        var coverFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

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
        var coverFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

        if (coverFromDb == null)
        {
            return NotFound();
        }
            
        _unitOfWork.CoverType.Remove(coverFromDb);
        _unitOfWork.Save();
        TempData["success"] = "CoverType deleted successfully";
        return RedirectToAction("Index");
    }
}