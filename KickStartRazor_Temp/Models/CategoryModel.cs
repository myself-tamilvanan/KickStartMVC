using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KickStartRazor_Temp.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; init; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; init; }
        [DisplayName("Display Order")]
        [Range(0, 100, ErrorMessage ="Display Order Must be between 1-100")]
        public int DisplaOrder { get; set; }
    }
}
