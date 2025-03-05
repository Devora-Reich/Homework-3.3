using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HW_3._3.Models
{
    public class NorthwindViewModel
    {
        public List<Order> Orders { get; set; }
        public DateTime DateNow { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}