using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserServiceAPI.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> Get();
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
