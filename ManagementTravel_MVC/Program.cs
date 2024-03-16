using Group5_Management_Library.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
//options =>
//{
//    options.LoginPath = "/Admin/Account/Login";
//  /*  options.ReturnUrlParameter = "returnUrl";*/
//}).AddCookie("Admin", options =>
//{
//    options.LoginPath = new PathString("/Admin/Account/Login");

//});
// Add services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Admin/Account/Login"; // ???ng d?n ??n trang ??ng nh?p
    options.ReturnUrlParameter = "returnUrl";
}).AddCookie("Admin", options =>
{
    options.LoginPath = new PathString("/Admin/Account/Login");
}).AddCookie("User", options =>
{
    options.LoginPath = new PathString("/Admin/Account/Login");
});
builder.Services.AddHttpClient();
//builder.Services.AddTransient<Product>;
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
    /*app.UseExceptionHandler("/Home/Error");*/
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePages();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); /// xác th?c quy?n truy c?p
app.UseAuthorization(); /// xác ??nh quy?n truy c?p


// Map area routes
/*app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=HomeAdmin}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "user",
    areaName: "User",
    pattern: "User/{controller=Home}/{action=Index}/{id?}");

// Map default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}");
app.Run();*/



app.MapControllerRoute(
    name: "client",
    pattern: "",
    defaults: new { area = "Client", Controller = "Customer", Action = "Index" }
/*   defaults: new { area = "Client", Controller = "Detail", Action = "Index" }*/
);

app.MapAreaControllerRoute(
   name: "client",
   areaName: "Client",
   pattern: "Client/{controller=Customer}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();