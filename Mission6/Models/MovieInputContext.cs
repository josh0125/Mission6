using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class MovieInputContext : DbContext
    {
        public MovieInputContext (DbContextOptions<MovieInputContext> options) : base(options)
        {

        }
        public DbSet<InputResponse> responses { get; set; }
        public DbSet<Category> categories { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1, CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Action and Adventure"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Horror"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Romantic Comedy"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Drama"
                }
                );

            mb.Entity<InputResponse>().HasData(
                new InputResponse
                {
                    InputID = 1,
                    Title = "Hitch",
                    Year= "2005",
                    CategoryID= 4,
                    Director= "Andy Tennant",
                    Rating= "PG-13",
                    Edited = true,
                    LentTo = "None",
                    Notes = "I go 90, you go 10"
                }, 
                new InputResponse
                {
                    InputID = 2,
                    Title = "Bourne Identity",
                    Year = "2002",
                    CategoryID = 2,
                    Director = "Doug Liman",
                    Rating = "PG-13"
                },
                new InputResponse
                {
                    InputID = 3,
                    Title = "Dune",
                    Year = "2021",
                    CategoryID = 2,
                    Director = "Denis Villeneuve",
                    Rating = "PG-13"
                }
                );
        }
    }
}
