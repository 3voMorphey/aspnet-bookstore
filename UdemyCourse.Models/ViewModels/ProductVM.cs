using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace UdemyCourse.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ProductVM
{
    public Product Product { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> CategoryList { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> CoverTypeList { get; set; }
}