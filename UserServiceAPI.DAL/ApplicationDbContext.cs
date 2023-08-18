using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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
                builder.ToTable(nameof(User));
                builder.HasKey("Id");
                builder.HasData(new User[]
                    {
                    new User()
                    {
                        Id = 1,
                        Email = "Test@mail.com",
                        NickName = "BurBon",
                        CreateDate = DateTime.Now,
                        Comments = "new test user"
                    },
                    new User()
                    {
                        Id = 2,
                        Email = "Test1@mail.com",
                        NickName = "Turbo",
                        CreateDate = DateTime.Now,
                        Comments = "second test user"
                    }
                });
            });
        }
    }
}

