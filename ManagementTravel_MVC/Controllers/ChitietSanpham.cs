using Microsoft.AspNetCore.Mvc;
using Project_Travel.Areas.Client.Models;

namespace Project_Travel.Areas.Client.Controllers
{
    public class ChitietSanpham : Controller
    {
        StoreContext objStoreContext = new StoreContext();
        public IActionResult Index(int id)
        {
            var objPageCustomer = objStoreContext.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objPageCustomer);
        }
    }
}
