using Microsoft.EntityFrameworkCore;
using System;
using UserServiceAPI.DAL.Entity;

namespace UserServiceAPI.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.HasData(
                    new User() { Id = 1, Email = "Test1@mail.com", NickName = "Buba", Comments = "test user", CreateDate = DateTime.Now },
                    new User() { Id = 2, Email = "Test2@mail.com", NickName = "Vogue", Comments = "test user", CreateDate = DateTime.Now },
                    new User() { Id = 3, Email = "Test3@mail.com", NickName = "Turbo", Comments = "test user", CreateDate = DateTime.Now },
                    new User() { Id = 4, Email = "Test4@mail.com", NickName = "ZiPRiP", Comments = "test user", CreateDate = DateTime.Now }

                    );
            });
        }
    }
}

