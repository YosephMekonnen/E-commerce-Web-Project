using E_commerce_Web_Project.DB;
using E_commerce_Web_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_Web_Project.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        EcommerceWebProjectEntities _context = new EcommerceWebProjectEntities();
        public ActionResult Index()
        {
            var product = _context.Products.ToList();
           

            return View(product);
        }

      
        public ActionResult OurProduct(string search = " ")
        {

            if (search.Equals(" "))
            {
                
                var lists = _context.Products.ToList();
                return View(lists);
            }
            else
            {
                var lists = _context.Products.Where(x => x.Category.CategoryName.Contains(search)).ToList();
                return View(lists);

            }


        }
    
           
        public ActionResult AddtoCart(int productId)
        {
            
           
            
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                var product = _context.Products.Find(productId);
              
                cart.Add(new Item()
                {
                    Product = product,
                    Stock = 1
                });
                Session["cart"] = cart;

            }
            else
            {
                List<Item> cart =(List<Item>)Session["cart"];
                var product = _context.Products.Find(productId);
                foreach(var item in cart.ToList())
                {
                    if (item.Product.ProductId == productId)
                    {
                        int prevItem = item.Stock;
                        cart.Remove(item);
                        cart.Add(new Item()
                        {
                            Product = product,
                            Stock = prevItem+1
                        });
                        break;
                    }
                    else
                    {
                        
                        cart.Add(new Item()
                        {
                            Product=product,
                            Stock=1
                        });
                        

                    }
                    
                }
            
                Session["cart"] = cart;

            }

           

            return Redirect("Index");

        }
        
     
     public ActionResult RemovefromCart(int productId)
        {
            List<Item> cart = (List<Item>)Session["cart"];
        

            foreach (var item in cart)
            {
               if (item.Product.ProductId == productId)
                {
                    cart.Remove(item);
                    break;
                }
              
            }
           


            Session["cart"] = cart;

            return Redirect("Index");
        }
        public ActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Checkout(Product_Order order)
        {
            _context.Product_Order.Add(order);
            _context.SaveChanges();
            

            return RedirectToAction("Index");
        }
      
       
    
     



    }
}