using Microsoft.EntityFrameworkCore;
using PeliculasApp.Models;

namespace PeliculasApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<PeliculaFavorita> PeliculasFavoritas { get; set; }
    }
}
