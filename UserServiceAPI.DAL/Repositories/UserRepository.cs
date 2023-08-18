using System.Linq;
using System.Threading.Tasks;
using UserServiceAPI.DAL.Entity;
using UserServiceAPI.DAL.Interfaces;

namespace UserServiceAPI.DAL.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

        }

        public IQueryable<User> Get()
        {
            return _context.Users;
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
