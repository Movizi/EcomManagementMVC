﻿using System.ComponentModel.DataAnnotations;

namespace EcomManagement.Models.Suppliers
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string SupplierName { get; set;}
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
