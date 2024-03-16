using Group5_Management_Library.Models;
using Group5_Management_Library.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using X.PagedList;

namespace ManagementTravel_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ProductController : BaseController
    {

        IProductsRepository productsRepository = null;
        private readonly HttpClient _httpClient = null;
        private string ProductApiUrl = "";

        public ProductController()
        {
            productsRepository = new ProductsRepository();
            _httpClient = new HttpClient();
            string apiUrl = "http://localhost:5000/api/Products";
           

        }
        public async Task<IActionResult> Index(int? page)
        {
            // API endpoint URL
            string apiUrl = "http://localhost:5000/api/Products";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                string strData = await response.Content.ReadAsStringAsync();
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                List<Product> listProducts = JsonSerializer.Deserialize<List<Product>>(strData, option);

                return View(listProducts.ToPagedList(page ?? 1, 5));
            }

        }
            // [HttpPost]
            //public ActionResult Create(Product products)
            //{
            //    try
            //    {
            // ProductsRepository.Inser(products);
            //        //SetAlert("Tạo mới thành công", "error");
            //        TempData["Message"] = "Tao moi thanh cong";
            //        return RedirectToAction("Index");
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}

    // POST: ProductController/Create

    //public async Task<IActionResult> Create(Product p)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        string strData = JsonSerializer.Serialize(p);
    //        var contentData = new StringContent(strData, Encoding.UTF8, "application/json");
    //        HttpResponseMessage res = await _httpClient.PostAsync(apiUrl, contentData);
    //        if (res.IsSuccessStatusCode)
    //        {
    //           // TempData["Message"] = "product inserted successfully";
    //            return RedirectToAction(nameof(Index));
    //        }
    //        else
    //        {
    //            TempData["Message"] = "Error while call Web API";
    //        }
    //    }
    //    return View(p);
    //}

    //public async Task<IActionResult> Create(Product product)
    //{
    //    // API endpoint URL for creating a new product
    //    string apiUrl = "http://localhost:5000/api/Products";

    //    // Convert the Product object to JSON
    //    string jsonProduct = JsonSerializer.Serialize(product);

    //    // Create HttpContent for the request body
    //    HttpContent content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");

    //    // Send a POST request to create a new product
    //    HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

    //    // Check if the request was successful (HTTP status code 2xx)
    //    if (response.IsSuccessStatusCode)
    //    {
    //        // Product creation successful
    //        return RedirectToAction("Index");
    //    }
    //    else
    //    {
    //        // Product creation failed, handle error
    //        string errorMessage = await response.Content.ReadAsStringAsync();
    //       // ModelState.AddModelError(string.Empty, errorMessage);
    //        return View();
    //    }
    //}


    /*IProductsRepository productsRepository = null;
   // IProductsCategoryRepository productsCategoryRepository = null;
    IUsersRepository userRepository = null;
    private readonly IWebHostEnvironment webHostEnvironment;
    public IActionResult Index(string? searchString, int? page, string sortBy, int? categoryId)
    {
        //Enumerable<ProductCategory> productsCategory = productsRepository.GetAllProductsCategory();
        //IEnumerable<User> users = userRepository.GetAll();
        // Tạo SelectList từ danh sách quyền truy cập
        //SelectList selectList = new SelectList(productsCategory, "Id", "CategoryName");

        // Lưu SelectList vào ViewBag để sử dụng trong View
        //ViewBag.ProductCategory = selectList;
        TempData["searchString"] = searchString != null ? searchString.ToLower() : "";
        int pageSize = 5;
        int pageNumber = (page ?? 1);
        //var products = productsRepository.GetProductsByKeyword(searchString, sortBy, categoryId).OrderByDescending(n => n.DateUpdate);
        //IPagedList<Product> productsList = new PagedList<Product>(products, pageNumber, pageSize);
        var productsCategoryUser = new ProductsCategoryUsers
        {
            //ProductsCategory = (ICollection<ProductCategory>)productsCategory,
            //Users = (ICollection<User>)users,
        };
        //productsCategoryUser.Products = productsList;
        return View(productsCategoryUser);*/
    //Get Admin/Roles.Create

    /* [HttpPost]
     public JsonResult Create(Product products)
     {
         try
         {
             // Lấy giá trị từ các trường thuộc tính của news trong form
             var model = new Product
             {
                 Name = products.Name,
                 Description = products.Description,
                 SubjectContent = products.SubjectContent,
                 CategoryId = products.CategoryId,
                 Avatar = products.Avatar,
                 Price = products.Price,
                 Quanlity = products.Quanlity,
                 Status = products.Status
             };
             //model.DateUpdate = Common.Common.GetServerDateTime();
             var user = User as ClaimsPrincipal;
             var userName = user?.FindFirstValue(ClaimTypes.Name);
             model.UserId = userRepository.GetByUserName(userName).UserId;
             productsRepository.InsertProduct(model);

             SetAlert("Insert Data is success!", "success");

             *//* }*//*
         }
         catch (Exception ex)
         {
             return Json(new { success = false, message = ex.Message });
         }
         return Json(new { success = true });
     }

     [HttpGet]
     public IActionResult Edit(int id)
     {
         Product products = productsRepository.GetProductByID(id);
         //ViewBag.NewsCategory = new SelectList(productsRepository.GetAllProductsCategory(), "Id", "CategoryName");
         var data = new
         {
             ProductId = id,
             Name = products.Name,
             Description = products.Description,
             SubjectContent = products.SubjectContent,
             CategoryId = products.CategoryId,
             DateUpdate = products.DateUpdate.ToString("dd/MM/yyyy"),
             Avatar = products.Avatar,
             Status = products.Status,
             UserId = products.UserId,
             Price = products.Price,
             Quanlity = products.Quanlity,
         };
         ViewBag.Anh = products.Avatar;
         return new JsonResult(new { success = true, data = data });
     }

     [HttpPost]
     public JsonResult Edit(Product products)
     {
         try
         {
             // Lấy giá trị từ các trường thuộc tính của user trong form
             var newp = new Product
             {
                 ProductId = products.ProductId,
                 Name = products.Name,
                 Description = products.Description,
                 SubjectContent = products.SubjectContent,
                 CategoryId = products.CategoryId,
                 Avatar = products.Avatar,
                 Status = products.Status,
                 UserId = products.UserId,
                 Price = products.Price,
                 Quanlity = products.Quanlity,
             };
             if (products.DateUpdate != null)
             {
                 newp.DateUpdate = DateTime.ParseExact(products.DateUpdate.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null);
             }
             productsRepository.UpdateProduct(newp);
             SetAlert("Update Data is success!", "success");

         }
         catch (Exception ex)
         {
             return Json(new { success = false, message = ex.Message });
         }
         return Json(new { success = true });
     }

     [HttpPost]
     public IActionResult Upload(IFormFile file)
     {
         if (file != null && file.Length > 0)
         {

             string wwwRootPath = webHostEnvironment.WebRootPath;
             // Tạo thư mục nếu nó không tồn tại
             *//* if (!Directory.Exists(uploadsFolder))
              {
                  Directory.CreateDirectory(uploadsFolder);
              }*//*
             string fileName = Path.GetFileNameWithoutExtension(file.FileName);
             //var filePath = Path.Combine(uploadsFolder, file.FileName);
             string extension = Path.GetExtension(file.FileName);
             ViewBag.Anh = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
             string path = Path.Combine(wwwRootPath + "/Upload/Images/", fileName);
             // Lưu tệp tin vào thư mục uploads
             using (var fileStream = new FileStream(path, FileMode.Create))
             {
                 file.CopyTo(fileStream);
             }

             var data = new
             {
                 Avatar = fileName,
             };
             return new JsonResult(new { success = true, data = data });
             // Trả về phản hồi thành công (nếu cần)
             //return Ok();
         }

         // Trả về phản hồi lỗi (nếu có)
         return BadRequest();
     }

     [HttpPost]
     public JsonResult ChangeStatus(int id)
     {
         //var result = productsRepository.ChangeStatus(id);
         return Json(new
         {
             //status = result
         });
     }

     [HttpPost]
     public JsonResult Delete(Product products)
     {
         try
         {
             //productsRepository.DeleteProduct(products);
             SetAlert("Delete Data is success!", "success");
         }
         catch (Exception ex)
         {
             return Json(new { success = false, message = ex.Message });
         }
         return Json(new { success = true });
     }*/

}
