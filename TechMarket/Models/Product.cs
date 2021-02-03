using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechMarket.Models
{
    public class Product
    {
        public int productid { get; set; }
        public string productbrand { get; set; }
        public string productmodel { get; set; }
        public int category { get; set; }
        public double price { get; set; }
        public int stock { get; set; }
        public Product(int productid, string productbrand, string productmodel, int category, double price, int stock)
        {
            this.productid = productid;
            this.productmodel = productmodel;
            this.productbrand = productbrand;
            this.category = category;
            this.price = price;
            this.stock = stock;
        }
        public Product()
        {

        }
    }
}