using E_commerce_Web_Project.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_commerce_Web_Project.Models
{
    public class Item
    {
        public Product Product { get; set; }
        public int Stock { get; set; }
       
    }
}