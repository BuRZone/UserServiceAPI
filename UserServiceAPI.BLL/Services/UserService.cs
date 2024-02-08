using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UserServiceAPI.BLL.Extensions;
using UserServiceAPI.BLL.Helpers;
using UserServiceAPI.BLL.Interfaces;
using UserServiceAPI.BLL.Models;
using UserServiceAPI.DAL.Interfaces;

namespace UserServiceAPI.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository repository, ILogger<UserService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<bool?> CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var userQ = (await _repository.GetAllAsync(cancellationToken))
                    .SingleOrDefault(x => x.Email == createUserDto.Email);
                if (userQ != null)
                {
                    _logger.LogInfoWithMethodName($"The User with Email {createUserDto.Email} allready exist");
                    return false;
                }
                if (UserValidator.UserValidation(createUserDto) == false)
                {
                    return false;
                }
                var user = createUserDto.MapFromDto();
                await _repository.CreateAsync(user, cancellationToken);
                _logger.LogInfoWithMethodName($"New User with Email {user.Email} was created");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error: {ex.Message}");
                return null;
            }
        }
        public async Task<bool?> DeleteUserAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var userQ = (await _repository.GetAllAsync(cancellationToken))
                    .SingleOrDefault(x => x.Id == id);
                if (userQ == null)
                {
                    _logger.LogInfoWithMethodName($"The User with id {id} not found");
                    return false;
                }

                await _repository.DeleteByIdAsync(userQ.Id, cancellationToken);
                _logger.LogInfoWithMethodName($"The User with id {id} was deleted");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error: {ex.Message}");
                return null;
            }
        }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public async Task<IEnumerable<UserDto>?> GetAllUsersAsync(CancellationToken cancellationToken = default)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {
            try
            {
                var userList = await _repository.GetAllAsync(cancellationToken);
                if (userList == null)
                    return Enumerable.Empty<UserDto>();
                var userDtoList = userList.MapListToDto();
                return userDtoList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error: {ex.Message}");
                return null;
            }
        }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public async Task<UserDto?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {
            try
            {
                var userQ = await _repository.GetByIdAsync(id, cancellationToken);
                if (userQ == null)
                {
                    _logger.LogInfoWithMethodName($"The User with id {id} not found");
                    return new UserDto();
                }
                var userDto = userQ.MapToDto();
                return userDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error: {ex.Message}");
                return null;
            }
        }

        public async Task<bool?> UpdateUserAsync(UpdateUserDto updateUserDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var userQ = (await _repository.GetAllAsync(cancellationToken))
                    .SingleOrDefault(x => x.Email == updateUserDto.Email);
                if (userQ == null)
                {
                    _logger.LogInfoWithMethodName($"The User with Email {updateUserDto.Email} not found");
                    return false;
                }
                else if (UserValidator.UserValidation(updateUserDto) == false)
                {
                    return false;
                }

                userQ.Email = updateUserDto.Email;
                userQ.NickName = updateUserDto.NickName;
                userQ.Comments = updateUserDto.Comments;
                userQ.CreateDate = updateUserDto.UpdatedDate;

                await _repository.UpdateAsync(userQ, cancellationToken);
                _logger.LogInfoWithMethodName($"The User with Email {userQ.Email} was updated");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error: {ex.Message}");
                return null;
            }
        }
    }
}