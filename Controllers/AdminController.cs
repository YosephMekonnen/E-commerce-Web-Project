using E_commerce_Web_Project.DB;
using E_commerce_Web_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_Web_Project.Controllers
{
   [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        ApplicationDbContext user = new ApplicationDbContext();
        EcommerceWebProjectEntities _context = new EcommerceWebProjectEntities();

        
        public ActionResult Dashboard()
        {
         

            var noOrders = _context.Product_Order.Count();
            var totalproducts = _context.Products.Count();
            var admins = user.Users.Count();
            ViewBag.admins = admins;
            ViewBag.orders = noOrders;
            ViewBag.totalProduct = totalproducts;
         
            return View();
        }
     
        public ActionResult GetCategories()
        {
            var categories = _context.Categories.ToList();

            return View(categories);
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            var add = _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("GetCategories");
        }
        public ActionResult EditCategory(int id)
        {
            var cat = _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();

            return View(cat);


        }
        [HttpPost]
        public ActionResult EditCategory(int id, Category category)
        {
            var cat = _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            if (category != null)
            {

                cat.CategoryName = category.CategoryName;
                cat.IsActive = category.IsActive;
                _context.SaveChanges();
            }

            return RedirectToAction("GetCategories", cat);

        }
        public ActionResult DeleteCategory(int id)
        {
            var deleteCategory = _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            _context.Categories.Remove(deleteCategory);
            _context.SaveChanges();

            return RedirectToAction("GetCategories");
        }
        
        public ActionResult Products()
        {
            var products = _context.Products.ToList();
            return View(products); 
        }
        public ActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product,HttpPostedFileBase Image)
        {
            string fileName = Path.GetFileNameWithoutExtension(product.Image.FileName);
            string exe = Path.GetExtension(product.Image.FileName);
            fileName = fileName + exe;
            product.ProductImage = fileName;
            fileName = Path.Combine(Server.MapPath("~/ProductImg/"), fileName);

        
            product.Image.SaveAs(fileName);

           _context.Products.Add(product);
                _context.SaveChanges();
            
            ModelState.Clear(); 
          

            return RedirectToAction("Products");
        }
        public ActionResult Delete(int? id)
        {
            var remove = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
          
            _context.Products.Remove(remove);
            _context.SaveChanges();
            return RedirectToAction("Products");

        }
        public ActionResult Edit(int? id)
        {
            var editProduct = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            return View(editProduct);
        }
        [HttpPost]
        public ActionResult Edit(Product product,HttpPostedFileBase Image)
        {
           

            var eProduct = _context.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
            
            
                eProduct.ProductName = product.ProductName;
                eProduct.Price = product.Price;
                eProduct.ProductDetails = product.ProductDetails;
                eProduct.CategoryId = product.CategoryId;
                eProduct.BrandId = product.BrandId;
                eProduct.IsActive = product.IsActive;
                eProduct.ProductImage =product.ProductImage;
                eProduct.IsFeatured = product.IsFeatured;
                eProduct.IsTrending = product.IsTrending;
                eProduct.Stock = product.Stock;
            

            _context.SaveChanges();
         

            return RedirectToAction("Products");

        }
        public ActionResult GetAllOrders()
        {

            var orders = _context.Product_Order.ToList();
            return View(orders);
        }
        public ActionResult EditOrder(int id)
        {

            var orderList = _context.Product_Order.Where(x => x.OrderId == id).FirstOrDefault();
            return View(orderList);

        }
        [HttpPost]
        public ActionResult EditOrder(int id,Product_Order order)
        {
            var orderList = _context.Product_Order.Where(x => x.OrderId == id).FirstOrDefault();

            if (order != null)
            {
                orderList.CustomerName = order.CustomerName;
                orderList.Address = order.Address;
                orderList.Status = order.Status;
                orderList.Action = order.Action;
                orderList.OrderDate = order.OrderDate;
                orderList.PhoneNumber = order.PhoneNumber;

                _context.SaveChanges();
            }
            return RedirectToAction("GetAllOrders");

        }


        public ActionResult DeleteOrder(int id)
        {
            var deleteOrder = _context.Product_Order.Where(x => x.OrderId == id).FirstOrDefault();
            _context.Product_Order.Remove(deleteOrder);
            _context.SaveChanges();


            return RedirectToAction("GetAllOrders");
        }

        public ActionResult AdminManage()
        {
            var admins = user.Users.ToList();
          
            return View(admins);
        }
     public ActionResult AdminDetails(string id)
        {
            var det = user.Users.Where(x => x.Id == id).FirstOrDefault();
            return View(det);
        }

      public ActionResult DeleteAdmin(string id)
        {
            var users = user.Users.Where(x => x.Id == id).FirstOrDefault();
            user.Users.Remove(users);
            user.SaveChanges();

            return RedirectToAction("AdminManage");
        }

          
    }
}
