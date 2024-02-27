using Microsoft.EntityFrameworkCore;
using Movies.API.Models;

namespace Movies.API.Data
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Movie>  Movies { get; set; }
    }
    
}
