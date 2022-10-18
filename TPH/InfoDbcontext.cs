using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TPH;


namespace TPH
{
    public class InfoDbcontext : DbContext
    {
        public InfoDbcontext()
        {

        }

        
        public DbSet<ProductionUnit> ProductionUnits { get; set; }

        
        public DbSet<Movies> Movies { get; set; }
        public DbSet<WebSeries> WebSeries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data SOurce=.;Initial Catalog=TPH; Integrated Security=SSPI;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // create a seed data
            var movies = new Movies[]
            {
                 new Movies(){ Id=1, Name="Dr.No",ReleaseYear=1963,
                     Category="Spy",BoxOfficeCollection=12222,PlayDuration=150},
                 new Movies(){ Id=2, Name="Golmal",ReleaseYear=1976,
                     Category="Comedy",BoxOfficeCollection=122,PlayDuration=180}
            };
            var series = new WebSeries[]
            {
                new WebSeries(){ Id=3, Name="Ramayan",ReleaseYear=1986,Seasons=2,EpisodPerSeason=100},
                new WebSeries(){ Id=4, Name="House of Cards",ReleaseYear=2005,Seasons=6,EpisodPerSeason=50}
            };

            var productionUnit = movies.Cast<ProductionUnit>()
                                    .Union(series)
                                    .ToList();

            modelBuilder.Entity<Movies>().HasData(movies);
            modelBuilder.Entity<WebSeries>().HasData(series);


            base.OnModelCreating(modelBuilder);
        }


    }
}
