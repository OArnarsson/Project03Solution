using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project03.Models
{
    public class Product
    {   
        public int productID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(300, MinimumLength = 3)]
        public string description { get; set; }

        [Required(ErrorMessage = "Catageory is required")]
        [Range(0, 9, ErrorMessage = "Category must be in the range of 0-9")]
        public int categoryID { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 1000000, ErrorMessage = "Price can not be lower than 0")]
        public double price { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [Range(0,1000000, ErrorMessage = "Stock must be in the range of 0-1000000")]
        public int stock { get; set; }
    }
}