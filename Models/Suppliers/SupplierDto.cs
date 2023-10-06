using System.ComponentModel.DataAnnotations;

namespace EcomManagement.Models.Suppliers
{
    public class SupplierDto
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
