using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyNetCoreMVC.Models;
using static MyNetCoreMVC.Models.MyDbContact;

namespace MyNetCoreMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyDbContact _context;
       

        public ProductController(MyDbContact context)
        {
            _context = context;
        }
       

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Update(Product product)
        {
            var exisProduct = _context.Products.Find(product.Id);
            if (exisProduct == null)
            {
                return NotFound();
            }

            exisProduct.Name = product.Name;
            exisProduct.Price = product.Price;
            _context.Products.Update(exisProduct);
            _context.SaveChanges();
            return Redirect("Index");

        }

        
        
            public IActionResult Edit(long id)
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }

        

        [HttpPost]
        public IActionResult Delete(long id)
        {
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Json(product);

        }

        [HttpPost]
       public IActionResult DeleteManny(string ids)
        {

            var stringProductIds = ids.Split(",");

            foreach (var productId in stringProductIds)
            {
                var product = _context.Products.Find(Convert.ToInt64(productId));
                if (product == null)
                {
                    return NotFound();
                }
                _context.Products.Remove(product);

            }
            _context.SaveChanges();
            TempData["message"] = "All the products deleted successfully";

            return Redirect("Index");

            //   string[] ids = formCollection["name"].Split(new char[] { ',' });

            //   foreach (string id in ids)
            //   {
            //       Product obj = _context.Products.Find(id);
            //           _context.Products.Remove(obj);
            //           _context.SaveChanges();
            //   }



            

            //return Json(isd);
        }



        public IActionResult Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Redirect("Index");
        } 

    }
}