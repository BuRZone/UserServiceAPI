using Microsoft.EntityFrameworkCore;
using UserServiceAPI.DAL.Entity;

namespace UserServiceAPI.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        
    }
}

