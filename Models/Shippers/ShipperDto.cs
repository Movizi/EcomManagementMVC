using System.ComponentModel.DataAnnotations;

namespace EcomManagement.Models.Shippers
{
    public class ShipperDto
    {
        public int ShipperID { get; set; }

        [Required]
        public string ShipperName { get; set; }

        [Required]
        public string Description { get; set; }

        public IFormFile Image { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }
        
        public bool IsActive { get; set; } = false;
        
        [Required]
        public decimal ShippingPrice { get; set; }

        [Required]
        public string Currency { get; set; }
    }
}
