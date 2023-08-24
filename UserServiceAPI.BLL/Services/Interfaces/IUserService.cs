using System.Linq;
using System.Threading.Tasks;
using UserServiceAPI.BLL.DTO;
using UserServiceAPI.DAL.Entity;

namespace UserServiceAPI.BLL.Services.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> Get();
        Task Create(UserDTO userDTO);
        Task Update(UserDTO userDTO);
        Task Delete(UserDTO userDTO);
    }
}
