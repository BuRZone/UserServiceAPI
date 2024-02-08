using System;
using System.Linq;
using UserServiceAPI.DAL.Entity;

namespace UserServiceAPI.DAL.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }
            var user1 = new User()
            {
                
                Email = "Test@mail.com",
                NickName = "BurBon",
                CreateDate = DateTime.Now.ToString(),
                Comments = "new test user"
            };
            var user2 = new User()
            {
                
                Email = "Test1@mail.com",
                NickName = "Turbo",
                CreateDate = DateTime.Now.ToString(),
                Comments = "second test user"
            };

            context.Users.AddRange(new User[] { user1, user2 });
            context.SaveChangesAsync();
        }
    }
}
