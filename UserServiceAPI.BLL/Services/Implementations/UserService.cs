using System;
using System.Linq;
using System.Threading.Tasks;
using UserServiceAPI.BLL.DTO;
using UserServiceAPI.BLL.Services.Interfaces;
using UserServiceAPI.DAL.Interfaces;
using UserServiceAPI.DAL.Entity;
using Microsoft.Extensions.Logging;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace UserServiceAPI.BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _repository;
        private readonly ILogger<UserService> _logger;
        public UserService(IBaseRepository<User> repository, ILogger<UserService> logger)
        {
            _repository = repository;
            _logger = logger;
            
        }
        public async Task Create(UserDTO userDTO)
        {
            try
            {
                var userQ = await _repository.Get().FirstOrDefaultAsync(p => p.Email.Equals(userDTO.Email));
                    
                if (userQ == null)
                {
                    //var userIdQ = _repository.Get().Select(x => x.Id).Max();

                    var user = new User()
                    {
                        Email = userDTO.Email,
                        NickName = userDTO.NickName,
                        Comments = userDTO.Comments,
                        CreateDate = DateTime.Now
                    };
                    await _repository.Create(user);
                    _logger.LogInformation($"[UserService.Create] создан новый пользователь {user.Email}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[UserService.Create] error: {ex.Message}");
            }
        }
        public async Task Delete(UserDTO userDTO)
        {
            try
            {
                var userQ = await _repository.Get().FirstOrDefaultAsync(x => x.Email == userDTO.Email);

                if (userQ != null)
                {
                    await _repository.Delete(userQ);
                    _logger.LogInformation($"[UserService.Delete] пользователь удален {userQ.Email}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[UserService.Delete] error: {ex.Message}");
            }
        }

        public IQueryable<User> Get()
        {
            return _repository.Get();
        }

        public async Task Update(UserDTO userDTO)
        {
            try
            {
                var userQ = await _repository.Get().FirstOrDefaultAsync(x => x.Email == userDTO.Email);

                if (userQ != null)
                {
                    userQ.NickName = userDTO.NickName;
                    userQ.Comments = userDTO.Comments;


                    await _repository.Update(userQ);
                    _logger.LogInformation($"[UserService.Update] пользователь обновлен {userQ.Email}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[UserService.Update] error: {ex.Message}");
            }
        }
    }
}
