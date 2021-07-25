using bookapi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace bookapi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Book> books{get;set;}
        
    }
}