﻿using System.ComponentModel.DataAnnotations;

namespace EcomManagement.Models.Categories
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
