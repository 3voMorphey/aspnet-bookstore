using System.ComponentModel;
using NodaTime;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UdemyCourse.Models
{
    public class Category
    {
        [Key]
        public int Id{ get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }

        public Instant CreatedDateTime { get; set; } = SystemClock.Instance.GetCurrentInstant();
    }
}
