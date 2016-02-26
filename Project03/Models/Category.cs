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
                myProducts.Add(new Product { productID = 0, name = "Cool hat", categoryID = 1, description = "Probably one of the coolest hats you will never see.", price = 9.99, stock = 1 });
                myProducts.Add(new Product { productID = 1, name = "Pair of socks", categoryID = 2, description = "I used to get cold feet, now I have socks.", price = 3.99, stock = 9 });
                myProducts.Add(new Product { productID = 2, name = "Dank weed", categoryID = 3, description = "This is some dank weed, son.", price = 50.99, stock = 3 });
                myProducts.Add(new Product { productID = 3, name = "Golf balls", categoryID = 4, description = "A pretty shitty golf ball if you ask me.", price = 0.99, stock = 100 });
                myProducts.Add(new Product { productID = 4, name = "Tan lotion", categoryID = 1, description = "This shit smells like BBQ sauce.", price = 7.99, stock = 12 });
                myProducts.Add(new Product { productID = 5, name = "Amazing hat", categoryID = 2, description = "A true hats only legends dare to own", price = 1050, stock = 4 });
                myProducts.Add(new Product { productID = 6, name = "Pair of pants", categoryID = 2, description = "I used to get cold feet, now I have socks, and those pants match any socks available", price = 13.99, stock = 9 });
                myProducts.Add(new Product { productID = 7, name = "Pure Muhammed Kushin", categoryID = 3, description = "Mashaala mahaed achmad, khaliiiiiiiiiiD!", price = 130.99, stock = 5 });
                myProducts.Add(new Product { productID = 8, name = "Ex-men's balls", categoryID = 4, description = "A pretty bad balls if u ask me, unable to contain the load", price = 0.99, stock = 100 });
                myProducts.Add(new Product { productID = 9, name = "Tan motion", categoryID = 2, description = "This Dance group is the hottest crew available, pay extra and you can have them smelling like BBQ sauce.", price = 7.99, stock = 12 });
            }

            return myProducts;
        }

        //Selects all products in that category
        public List<Product> GetProductsByCategoryID (int id)
        {
            List <Product> inCategory = (from Product in myProducts where Product.categoryID == id select Product).ToList();

            if(inCategory.Count == 0)
            {
                myProducts.Add(new Product { name = "No products!", categoryID = 999, description = "", price = 0, stock = 0 });
            }
                             

            return inCategory;
        }

        public Product GetProductByID(int id)
        {
           Product result = (from Product in myProducts where Product.productID == id select Product).SingleOrDefault();

            return result;
        }

        public void AddProduct(Product prod)
        {
            prod.productID = (from Product in myProducts
                              select prod.productID).Max() + 1;

            myProducts.Add(prod);
        }

        public void UpdateProduct(Product prod)
        {
            for (int i = 0; i < myProducts.Count; i++)
            {
                if (prod.productID == myProducts[i].productID)
                {
                    myProducts[i] = prod;
                    break;
                }
            }
        }

    }
}