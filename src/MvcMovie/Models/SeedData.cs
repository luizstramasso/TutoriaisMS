using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                if (context.Movie.Any())
                {
                    return;
                }

                context.Movie.AddRange(
                    new Movie { Title = "When Harry Met Sally", ReleseDate = DateTime.Parse("12/02/1989"), Genre = "Romantic Comedy", Price = 7.99M, Rating = "R" },
                    new Movie { Title = "Ghostbusters", ReleseDate = DateTime.Parse("13/03/1984"), Genre = "Comedy", Price = 8.99M, Rating = "R" },
                    new Movie { Title = "Ghostbusters 2", ReleseDate = DateTime.Parse("23/02/1986"), Genre = "Comedy", Price = 9.99M, Rating = "R" },
                    new Movie { Title = "Rio Bravo", ReleseDate = DateTime.Parse("15/04/1959"), Genre = "Western", Price = 3.99M, Rating = "R" }
                    );
                context.SaveChanges();
            }
        }
    }
}
