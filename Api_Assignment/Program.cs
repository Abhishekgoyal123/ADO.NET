using Microsoft.EntityFrameworkCore;
using Api_Assignment.Models;
using Api_Assignment;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDbContext<eShoppingCodiContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection"));

});


builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbAccessService<Category, int>, CategoryDataAccessService>();
//builder.Services.AddScoped<IDbAccessService<Product, int>, ProductDataAccessService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();