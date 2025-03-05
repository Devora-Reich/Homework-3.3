using HW_3._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW_3._3.Controllers
{
    public class NorthwindController : Controller
    {
        // GET: Northwind
        public ActionResult orders()
        {
            NorthwindManager nm = new NorthwindManager(Properties.Settings.Default.ConStr);
            NorthwindViewModel nvm = new NorthwindViewModel();
            nvm.Orders = nm.GetOrders();
            nvm.DateNow = DateTime.Now;

            return View(nvm);
        }
        public ActionResult orderdetails()
        {
            NorthwindManager nm = new NorthwindManager(Properties.Settings.Default.ConStr);
            NorthwindViewModel nvm = new NorthwindViewModel();
            nvm.OrderDetails = nm.GetOrderDetails();

            return View(nvm);
        }
    }
}