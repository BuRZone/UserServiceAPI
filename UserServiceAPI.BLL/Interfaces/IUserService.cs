using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UserServiceAPI.BLL.Models;

namespace UserServiceAPI.BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>?> GetAllUsersAsync(CancellationToken cancellationToken = default);
        Task<UserDto?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool?> CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken = default);
        Task<bool?> UpdateUserAsync(UpdateUserDto updateUserDto, CancellationToken cancellationToken = default);
        Task<bool?> DeleteUserAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
