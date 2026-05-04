using System.ComponentModel.DataAnnotations;

namespace AdminTask.Models
{
    public class Product : BaseEntity
    {
        //title
        [Required(ErrorMessage = "Title is required")]
        [StringLength(20, ErrorMessage = "Title must be less than 20 characters")]
        public string Title { get; set; }

        //image url
        [Required(ErrorMessage = "Image URL is required")]
        public string  ImageUrl { get; set; }

        //major
        [Required(ErrorMessage = "Major is required")]
        [StringLength(20, ErrorMessage = "Major must be less than 20 characters")]
        public string Major { get; set; }
    }
}
