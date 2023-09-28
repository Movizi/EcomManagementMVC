using System.ComponentModel.DataAnnotations;

namespace EcomManagement.Models.Products
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public short UnitsInStock { get; set; }
    }
}
