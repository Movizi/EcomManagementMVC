using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EcomManagement.Models.Suppliers;
using EcomManagement.Models.Categories;
using EcomManagement.Models.Enums;

namespace EcomManagement.Models.Products
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string SupplierName { get; set; }

        public string CategoryName { get; set; }

        public decimal Price { get; set; }

        public int UnitsInStock { get; set; }
        public Currencies Currency { get; set; }
    }
}
