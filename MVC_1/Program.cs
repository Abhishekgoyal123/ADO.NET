using Coditas.Ecomm.Repositories;
using Coditas.EComm.DataAccess;
using Coditas.EComm.DataAccess.Models;
using Coditas.EComm.Entities;
using Coditas.EComm.Repositories;
using Microsoft.EntityFrameworkCore;
using MVC_1;
using MVC_1.CustomFilters;
using MVC_Apps.CustomFilters;
using Microsoft.AspNetCore.Identity;
using MVC_1.Data;
using MVC_1.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<eShoppingCodiContext>(opt =>

opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddDbContext<SecurityDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SecurityDbContextConnection"));
});

// AdddDefaultIdentity<IdentityUser>() for the user based authentication.
// SignIn.RequireConfirmedAccount = false the email must be verified.
// AddEntityFrameworkStores<SecurityDbContext>(); read users iformation using EF core


//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<SecurityDbContext>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>( options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<SecurityDbContext>().AddDefaultUI();

builder.Services.AddScoped<IDbRepository<Category, int>, CategoryRepository>();
builder.Services.AddScoped<IDbRepository<Product, int>, ProductRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
   // options.Filters.Add(typeof(CustomLogRequestAttribute));
    // REgister the Exception Filter
    options.Filters.Add(typeof(AppExceptionAttribute));
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ReadPolicy", policy =>
    {
        policy.RequireRole("Manager");
    });
    options.AddPolicy("CreatePolicy", policy =>
    {
        policy.RequireRole("User");
    });
});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// middleware used to read/write files on server for upload and download.
// by default this is used to read content of 'www.root' folder.
app.UseStaticFiles();

// create load and execute route table for mvc controller routing to execute an action method of a controller class. 
app.UseRouting();

app.UseSession();
app.UseAuthentication();;

// used in role based security
app.UseAuthorization();

// map the incoming http request to the corresponding controller and the action method from controller 
// {id?} is nullable parameter which is scalar type variable passed to action method.


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
