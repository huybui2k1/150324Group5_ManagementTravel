using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Travel.Areas.Client.Models;

namespace Project_Travel.Areas.Client.Controllers
{
    public class DetailsController : Controller
    {

        StoreContext objStoreContext = new StoreContext();
        // GET: DetailsController
        public ActionResult Index()
        {
            ProductModel objProductModel = new ProductModel();
            objProductModel.LisProduct = objStoreContext.Products.ToList();
            return View(objProductModel);
        }

        // GET: DetailsController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: DetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
