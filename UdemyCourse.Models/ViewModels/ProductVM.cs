namespace UdemyCourse.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ProductVM
{
    public Product Product { get; set; }
    public IEnumerable<SelectListItem> CategoryList { get; set; }
    public IEnumerable<SelectListItem> CoverTypeList { get; set; }
}