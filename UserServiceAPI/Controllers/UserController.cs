using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;
using UserServiceAPI.BLL.DTO;
using UserServiceAPI.BLL.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace UserServiceAPI.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserDTO> _logger;
        public UserController(IUserService userService, ILogger<UserDTO> logger)
        {
            _userService = userService;
            _logger = logger;
        }


        [Route("api/List")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            List<UserDTO> userDTOList = new List<UserDTO>();
            var userQ = await _userService.Get().ToListAsync();
            if (userQ.Count != 0)
            {
                foreach (var user in userQ)
                {
                    UserDTO userDTO = new UserDTO()
                    {
                        Email = user.Email,
                        NickName = user.NickName,
                        Comments = user.Comments,
                        CreateDate = user.CreateDate
                    };
                    userDTOList.Add(userDTO);
                }
                return Ok(userDTOList);
            }
            return BadRequest("no User found");
        }

        [Route("api/Get")]
        [HttpGet]
        public async Task<IActionResult> Get(string jsonString)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            UserDTO userDTO = JsonSerializer.Deserialize<UserDTO>(jsonString, options);
            var userQ = await _userService.Get().FirstOrDefaultAsync(x => x.Email == userDTO.Email);
            if (userQ != null)
            {
                var UserDTO = new UserDTO()
                {
                    Email = userQ.Email,
                    NickName = userQ.NickName,
                    Comments = userQ.Comments,
                    CreateDate = userQ.CreateDate
                };
                return Ok(UserDTO);
            }
            return BadRequest("User not found");

        }
        [Route("api/Create")]
        [HttpPost]
        public async Task<IActionResult> Create(string jsonString)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            UserDTO userDTO = JsonSerializer.Deserialize<UserDTO>(jsonString, options);
            var userQ = await _userService.Get().FirstOrDefaultAsync(x => x.Email == userDTO.Email);
            if (userQ != null)
            {
                return BadRequest("User allready exist");
            }

            await _userService.Create(userDTO);

            var userQuery  = await _userService.Get().FirstOrDefaultAsync(x => x.Email == userDTO.Email);
            if (userQuery != null)
            {
                return Ok("User seccesfully created");
            }
            return BadRequest("что то пошло не так");
            
        }

        [Route("api/Update")]
        [HttpPut]
        public async Task<IActionResult> Update(string jsonString)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            UserDTO userDTO = JsonSerializer.Deserialize<UserDTO>(jsonString, options);
            var userQ = await _userService.Get().FirstOrDefaultAsync(x => x.Email == userDTO.Email);
            if (userQ != null) 
            {
                await _userService.Update(userDTO);
                return Ok("User updated seccesfully");
            }
            return BadRequest();

        }

        [Route("api/Delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string jsonString)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            UserDTO userDTO = JsonSerializer.Deserialize<UserDTO>(jsonString, options);
            var userQ = await _userService.Get().FirstOrDefaultAsync(x => x.Email == userDTO.Email);
            if (userQ != null)
            {
                await _userService.Delete(userDTO);
                return Ok("User deleted seccesfully");
            }
            return BadRequest();

        }
    }
}
