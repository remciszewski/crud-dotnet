using CRUDWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDWeb.Data
{
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options)
        {
            
        }

        public DbSet<List> Lists { get; set; } 
    }
}
