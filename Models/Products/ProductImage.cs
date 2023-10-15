using System.ComponentModel.DataAnnotations;

namespace EcomManagement.Models.Products
{
    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public int ProductId { get; set; }
        
        [Required]
        public string Image { get; set; }
    }
}
