using EcomManagement.Models.Categories;
using EcomManagement.Models.Suppliers;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomManagement.Models.Products
{
    public class ProductDto
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        [Required]
        public int SupplierID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int UnitsInStock { get; set; }

        public List<ProductImageDto> Images { get; set; }

        [ForeignKey("SupplierID")]
        public Supplier Supplier { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
    }
}
