using Microsoft.AspNetCore.Mvc;
using Project_Travel.Areas.Client.Models;
using System;

[Route("/products")]
public class ShoppingController : Controller
{
    private readonly ILogger<ShoppingController> _logger;
    private readonly StoreContext _context;

    public ShoppingController(ILogger<ShoppingController> logger, StoreContext context)
    {
        _logger = logger;
        _context = context;
    }

    // Hiện thị danh sách sản phẩm, có nút chọn đưa vào giỏ hàng
    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }

    /// Thêm sản phẩm vào cart
    [Route("addcart/{productid:int}")]
    public IActionResult AddToCart([FromRoute] int productid)
    {

        var product = _context.Products
                        .Where(p => p.Id == productid)
                        .FirstOrDefault();
        if (product == null)
            return NotFound("Không có sản phẩm");

        // Xử lý đưa vào Cart ...


        return RedirectToAction(nameof(Cart));
    }
    /// xóa item trong cart
    [Route("/removecart/{productid:int}", Name = "removecart")]
    public IActionResult RemoveCart([FromRoute] int productid)
    {

        // Xử lý xóa một mục của Cart ...
        return RedirectToAction(nameof(Cart));
    }

    /// Cập nhật
    [Route("/updatecart", Name = "updatecart")]
    [HttpPost]
    public IActionResult UpdateCart([FromForm] int productid, [FromForm] int quantity)
    {
        // Cập nhật Cart thay đổi số lượng quantity ...

        return RedirectToAction(nameof(Cart));
    }


    // Hiện thị giỏ hàng
    [Route("/cart", Name = "cart")]
    public IActionResult Cart()
    {
        return View();
    }

    [Route("/checkout")]
    public IActionResult CheckOut()
    {
        // Xử lý khi đặt hàng
        return View();
    }

}