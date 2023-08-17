using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserServiceAPI.BLL.DTO;
using UserServiceAPI.DAL.Entity;

namespace UserServiceAPI.BLL.Services.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> Get();
        Task Create(UserDTO userDTO);
        Task Update(string email, UserDTO userDTO);
        Task Delete(string email);
    }
}
