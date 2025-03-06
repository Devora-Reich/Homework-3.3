using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW_3._3.Models
{
    public class NorthwindProductsModel
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public string CategoryName { get; set; }
    }
}