using System.ComponentModel.DataAnnotations;

namespace UdemyCourse.Models;

public class CoverType
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "Cover")]
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
}