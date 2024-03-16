using Group5_Management_Library.Models;
using Group5_Management_Library.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using X.PagedList;

namespace ManagementTravel_MVC.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class StaffController : BaseController
    {
        IStaffRepository staffRepository = null;
        public StaffController() => staffRepository = new StaffRepository();

        public IActionResult GetCityID(string searchString, string CityName, int? page, string sortBy)
        {
            var nhanvienList = staffRepository.GetStaffByName(searchString is null ? null : searchString, CityName is null ? null : CityName.ToLower(), sortBy).ToPagedList(page ?? 1, 5);
            return Ok(nhanvienList);
        }

        [HttpGet]
        public ActionResult Index(string searchString, string CityName, int? page, string sortBy)
        {
            var nhanvienList = staffRepository.GetStaffByName(searchString is null ? null : searchString.ToLower(), CityName is null ? null : CityName.ToLower(), sortBy).ToPagedList(page ?? 1, 5);
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                nhanvienList = staffRepository.GetStaffByName(searchString,CityName, sortBy).ToPagedList(page ?? 1, 5);
            }

            //Hiển thị thành phố
            var citys = new List<SelectListItem>
    {
        new SelectListItem { Value = "1", Text = "Đà Nẵng" },
        new SelectListItem { Value = "2", Text = "Huế" },
        new SelectListItem { Value = "3", Text = "Quảng Bình" }
    };

            ViewBag.City = citys;

            //TempData["searchString"] = searchString;
            return View(nhanvienList);

        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Staff kh)
        {
            try
            {
                
                    staffRepository.InsertStaff(kh);
                TempData["Messsage"] = "Tao moi thanh cong ";
                    //SetAlert("Tạo mới thành công", "error");
                    return RedirectToAction("Index");
               
            }
            catch
            {
                return View();
            }
           
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var kh = staffRepository.GetStaffByID(id);
            return View(kh);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Staff kh)
        {
            try
            {
                staffRepository.UpdateStaff(kh);
                SetAlert("Cập nhật thành công", "error");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        /* public ActionResult Delete(int id)
         {
             return View();
         }*/

        [HttpPost]
        public JsonResult DeleteId(int id)
        {
            try
            {
                var record = staffRepository.GetStaffByID(id);
                if (record == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy bản ghi" });
                }
                staffRepository.DeleteStaff(id);
                SetAlert("Xoá thành công", "error");
                /*return Json(new { success = true, id = id});*/
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // POST: CustomerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                staffRepository.DeleteStaff(id);
                SetAlert("Xoá thành công", "error");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult DeleteMultiple(IEnumerable<int> SelectedCatDelete)
        {
            if (SelectedCatDelete.Count() == 0)
            {
                ViewBag.DelError = "Yes";
                ViewBag.DelTitle = "Delete operation has not been completed";
                ViewBag.DelMessage = "This record can not be deleted, beacuse one or more cost record use this customer.";
                return View("Error");
                //return RedirectToAction("ExceptionError", "Error", new { area = "" });
            }
            staffRepository.DeleteSelectedStaff(SelectedCatDelete);
            TempData["Message"] = $"Xoá {SelectedCatDelete.Count()} hàng thành công";
            return RedirectToAction("Index");
        }


        public JsonResult ListName(string q)
        {
            if (!string.IsNullOrEmpty(q))
            {
                var data = staffRepository.GetStaffByName(q.ToLower(), "", "name");
                var responseData = data.Select(kh => kh.StaffId).ToList();
                return Json(new
                {
                    data = responseData,
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }

    }
}
