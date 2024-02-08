using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UserServiceAPI.DAL.Data;
using UserServiceAPI.DAL.Entity;
using UserServiceAPI.DAL.Interfaces;

namespace UserServiceAPI.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _context;

        public UserRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var userList = await _context.Users.AsNoTracking().ToListAsync(cancellationToken);
            return userList;
        }
        public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            return user;
        }
        public async Task CreateAsync(User user, CancellationToken cancellationToken = default)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
