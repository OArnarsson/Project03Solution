using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project03.Models
{
    public class Product
    {
        public string name { get; set; }
        public string description { get; set; }
        public int categoryID { get; set; }
        public double price { get; set; }
        public int stock { get; set; }
    }
}