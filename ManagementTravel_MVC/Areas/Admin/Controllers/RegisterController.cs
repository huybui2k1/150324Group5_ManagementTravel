using Microsoft.AspNetCore.Mvc;
using ManagementTravel_MVC.Models;

namespace ManagementTravel_MVC.Areas.Admin.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Lưu dữ liệu vào cơ sở dữ liệu hoặc thực hiện các xử lý khác
                return RedirectToAction("Success");
            }
            else
            {
                // Trả về view đăng ký với các thông báo lỗi
                return View(model);
            }
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
