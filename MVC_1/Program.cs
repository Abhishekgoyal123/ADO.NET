var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

// used in role based security
app.UseAuthorization();

// map the incoming http request to the corresponding controller and the action method from controller 
// {id?} is nullable parameter which is scalar type variable passed to action method.


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
