using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelExample.Models;  

namespace ModelExample.Controllers
{
    public class ProductsController : Controller
    {
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { ProductId = 101, ProductName = "AC", Rate = 45000 },
                new Product() { ProductId = 102, ProductName = "Mobile", Rate = 38000 },
                new Product() { ProductId = 103, ProductName = "Bike", Rate = 94000 }
            };
            return products;
        }
        public ActionResult Index()
        {
            ViewBag.products = GetProducts();
            return View();
        }

        public ActionResult Details(int id)
        {
            ViewBag.product = GetProducts().FirstOrDefault(pr=>pr.ProductId==id);
            return View();
        }
    }
}



