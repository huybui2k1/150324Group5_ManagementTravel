using Microsoft.AspNetCore.Mvc;
using Project_Travel.Areas.Client.Models;

namespace Project_Travel.Areas.Client.Controllers
{


    public class LoginController : Controller
    {
        StoreContext objStoreContext = new StoreContext();

        public IActionResult Index()
        {
            return View();
        }
    }
}
