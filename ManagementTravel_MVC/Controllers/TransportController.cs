using Microsoft.AspNetCore.Mvc;
using Project_Travel.Areas.Client.Models;

namespace Project_Travel.Areas.Client.Controllers
{
    public class TransportController : Controller
    {

        StoreContext objStoreContext = new StoreContext();
        public IActionResult Index()
        {
            ProductModel objProductModel = new ProductModel();
            objProductModel.LisProduct = objStoreContext.Products.ToList();
            return View(objProductModel);
           
        }
    }
}
