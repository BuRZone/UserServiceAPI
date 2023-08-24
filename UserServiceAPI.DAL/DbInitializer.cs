using System;
using System.Linq;
using UserServiceAPI.DAL.Entity;

namespace UserServiceAPI.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context) 
        {
            if (context.Users.Any())
            {
                return;
            }
            var user1 = new User()
            {
                Email = "Test@mail.com",
                NickName = "BurBon",
                CreateDate = DateTime.Now,
                Comments = "new test user"
            };
            var user2 = new User()
            {
                Email = "Test1@mail.com",
                NickName = "Turbo",
                CreateDate = DateTime.Now,
                Comments = "second test user"
            };
            var users = new User[]{ user1, user2 };

            context.AddRangeAsync(users);
            context.SaveChangesAsync();


        }
    }
}
