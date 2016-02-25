using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project03.Models
{
    public class Category
    {
        private static List<Product> myProducts = new List<Product>();


        //Lists out all current products.
        public List<Product> GetAllProducts()
        {
            if (myProducts.Count == 0)
            {
                myProducts.Add(new Product { name = "Cool hat", categoryID = 0, description = "Probably one of the coolest hats you will never see.", price = 9.99, stock = 1 });
                myProducts.Add(new Product { name = "Pair of socks", categoryID = 0, description = "I used to get cold feet, now I have socks.", price = 3.99, stock = 9 });
                myProducts.Add(new Product { name = "Dank weed", categoryID = 0, description = "This is some dank weed, son.", price = 50.99, stock = 3 });
                myProducts.Add(new Product { name = "Golf balls", categoryID = 4, description = "A pretty shitty golf ball if you ask me.", price = 0.99, stock = 100 });
                myProducts.Add(new Product { name = "Tan lotion", categoryID = 4, description = "This shit smells like BBQ sauce.", price = 7.99, stock = 12 });
            }

            return myProducts;
        }

        //Selects all products in that category
        public List<Product> GetProductsByCategoryID (int id)
        {
            List <Product> inCategory = (from Product in myProducts where Product.categoryID == id select Product).ToList();
                             

            return inCategory;
        }
        
            
    }
}