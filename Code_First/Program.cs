// See https://aka.ms/new-console-template for more information
using Code_First.Models;
Console.WriteLine("Hello, World!");

InfoDbContext ctx = new InfoDbContext();
Category cat = new Category();
cat.CategoryId = "Cat-001";
cat.CategoryName = "IT";
cat.BasePrice = 300;
ctx.Categories.Add(cat);
ctx.SaveChanges();

Product prd = new Product();
prd.ProductId = "Prd-001";
prd.ProductName = "Laptop";
prd.Manufacturer = "HP";
prd.Price = 90000;
prd.CategoryRowId = 1;
ctx.Products.Add(prd);
ctx.SaveChanges();


Product prd1 = new Product();
prd.ProductId = "Prd-002";
prd.ProductName = "computer";
prd.Manufacturer = "lenovo";
prd.Price = 9999;
prd.CategoryRowId = 1;
ctx.Products.Add(prd1);
ctx.SaveChanges();
