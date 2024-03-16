using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ManagementTravel_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class OrdersController : BaseController
    {
        /*ICustomersRepository CustomerRepository = null;*/
        private readonly HttpClient _httpClient = null;
        private string ProductApiUrl = "";
        public OrdersController()
        {
            _httpClient = new HttpClient();
            string apiUrl = "http://localhost:5000/api/Orders";
            /* CustomerRepository = new CustomersRepository();*/
            // GET: CustomerController

        }
        public async Task<IActionResult> Index()
        {
            //// API endpoint URL
            //string apiUrl = "http://localhost:5000/api/Orders";
            //HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            //string strData = await response.Content.ReadAsStringAsync();
            //var option = new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true,
            //};
            //List<OrderDto> listOrder = JsonSerializer.Deserialize<List<OrderDto>>(strData, option);

            //return View(listOrder);
            return View();
        }



        //public class OrdersController : Controller
        //{
        //    public async Task<List<OrderDto>> GetOrdersFromApi()
        //    {
        //        // API endpoint URL for retrieving orders
        //        string apiUrl = "http://localhost:5000/api/Orders"; // Adjust the URL based on your API endpoint

        //        // Send a GET request to retrieve orders
        //        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            // Deserialize the response content to get the list of orders
        //            string responseData = await response.Content.ReadAsStringAsync();
        //            var orders = JsonSerializer.Deserialize<List<OrderDto>>(responseData, new JsonSerializerOptions
        //            {
        //                PropertyNameCaseInsensitive = true,
        //            });

        //            return orders;
        //        }
        //        else
        //        {
        //            // Handle the error if the request is not successful
        //            // You might want to log or handle the error appropriately
        //            ModelState.AddModelError(string.Empty, "Error retrieving orders from the API");
        //            return null;
        //        }
        //    }
        //    public async Task<IActionResult> Index()
        //    {
        //        await GetOrdersFromApi();
        //        View();

        //    }


        //    }



    }
}
