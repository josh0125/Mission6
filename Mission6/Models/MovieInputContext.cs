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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<InputResponse>().HasData(
                new InputResponse
                {
                    InputID = 1,
                    Title = "Hitch",
                    Year= "2005",
                    CategoryID= 1,
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
                    CategoryID = 1,
                    Director = "Doug Liman",
                    Rating = "PG-13"
                },
                new InputResponse
                {
                    InputID = 3,
                    Title = "Dune",
                    Year = "2021",
                    CategoryID = 1,
                    Director = "Denis Villeneuve",
                    Rating = "PG-13"
                }
                );
        }
    }
}
