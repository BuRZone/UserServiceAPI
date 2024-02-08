using System.Collections.Generic;
using UserServiceAPI.BLL.Models;
using UserServiceAPI.DAL.Entity;

namespace UserServiceAPI.BLL.Extensions
{
    public static class ModelExtensions
    {
        public static UserDto MapToDto(this User user)
        {
            UserDto userDto = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                NickName = user.NickName,
                Comments = user.Comments,
                CreateDate = user.CreateDate
            };
            return userDto;
        }
        public static User MapFromDto(this CreateUserDto createUserDto)
        {
            User user = new User
            {
                Email = createUserDto.Email,
                NickName = createUserDto.NickName,
                Comments = createUserDto.Comments,
                CreateDate = createUserDto.CreateDate
            };
            return user;
        }
        public static IEnumerable<UserDto> MapListToDto(this IEnumerable<User> userList)
        {
            List<UserDto> userDtoList = new List<UserDto>();
            foreach (User user in userList)
            {
                UserDto userDto = new UserDto()
                {
                    Id = user.Id,
                    Email = user.Email,
                    NickName = user.NickName,
                    Comments = user.Comments,
                    CreateDate = user.CreateDate
                };
                userDtoList.Add(userDto);
            }
            return userDtoList;
        }
    }
}
