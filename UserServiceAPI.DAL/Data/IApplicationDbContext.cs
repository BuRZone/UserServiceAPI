using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserServiceAPI.DAL.Entity;

namespace UserServiceAPI.DAL.Data
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<User> Users { get; set; } 
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
