using Movies.API.Models;

namespace Movies.API.Data
{
    public class MoviesContextSeed
    {
        public static void SeedAsync(MovieDbContext dbContext)
        {
            if (!dbContext.Movies.Any())
            {
                var movies = new List<Movie>
                {
                    new Movie { CreatedAt = DateTime.Now, Genre = "Drama", Name="The Shawshank Redemption", Owner="alice" },
                    new Movie { CreatedAt = DateTime.Now.AddDays(-100), Genre = "Drama1", Name="The Shawshank Redemption1", Owner="alice1" },
                    new Movie { CreatedAt = DateTime.Now.AddDays(-20), Genre = "Drama2", Name="The Shawshank Redemption2", Owner="alice2" },
                    new Movie { CreatedAt = DateTime.Now.AddDays(100), Genre = "Drama2", Name="The Shawshank Redemption2", Owner="alice2" },
                };
                dbContext.Movies.AddRange(movies);
                dbContext.SaveChanges();
            }
        }
    }
}
