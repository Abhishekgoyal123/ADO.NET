// See https://aka.ms/new-console-template for more information
using TPH;

InfoDbcontext ctx = new InfoDbcontext();

Movies movie = new Movies()
{
    // Id = 9,
    Name = "No Time For Die",
    ReleaseYear = 2021,
    BoxOfficeCollection = 90000,
    Category = "Spy",
    PlayDuration = 180
};
ctx.ProductionUnits.Add(movie);
ctx.SaveChanges();



Console.ReadLine();