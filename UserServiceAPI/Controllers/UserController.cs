using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using UserServiceAPI.BLL.DTO;
using UserServiceAPI.BLL.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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

        [Route("/api/List")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<UserDTO> userDTOs = new List<UserDTO>(); 
            var usersQ = await _userService.Get().ToListAsync();
            foreach (var user in usersQ)
            {
                UserDTO userDTO = new UserDTO()
                {
                    Id = user.Id,
                    Email = user.Email,
                    NickName = user.NickName,
                    Comments = user.Comments,
                    CreateDate = user.CreateDate,
                };
                userDTOs.Add(userDTO);
            }
            return Ok(userDTOs);
        }

            [Route("api/Get")]
        [HttpGet]
        public async Task<IActionResult> Get(string jsonString)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            UserDTO userDTOQ = JsonSerializer.Deserialize<UserDTO>(jsonString, options);
            

            var userQ = await _userService.Get().FirstOrDefaultAsync(x => x.Email == userDTOQ.Email);
            if (userQ != null)
            {
                var UserDTO = new UserDTO()
                {
                    Id = userQ.Id,
                    Email = userQ.Email,
                    NickName = userQ.NickName,
                    Comments = userQ.Comments,
                    CreateDate = userQ.CreateDate
                };
                return Ok(UserDTO);
            }
            return NotFound("User not found");

        }
        [Route("api/Create")]
        [HttpPost]
        public async Task<IActionResult> Create(string jsonString)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            UserDTO userDTOQ = JsonSerializer.Deserialize<UserDTO>(jsonString, options);

            var userQ = await _userService.Get().FirstOrDefaultAsync(x => x.Email == userDTOQ.Email);
            if (userQ != null)
            {
                return Ok("User allready exist");
            }
            var userDTO = new UserDTO()
            {
                Id = default,
                Email = userDTOQ.Email,
                NickName = userDTOQ.NickName,
                Comments = userDTOQ.Comments,
                CreateDate = default
            };

            await _userService.Create(userDTO);
            var newUser = await _userService.Get().FirstOrDefaultAsync(x => x.Email == userDTOQ.Email);
            if (newUser != null) 
            {
                UserDTO user = new UserDTO()
                {
                    Id = newUser.Id,
                    Email = newUser.Email,
                    NickName = newUser.NickName,
                    Comments = newUser.Comments,
                    CreateDate = newUser.CreateDate
                };
                string json = JsonSerializer.Serialize(user);
                return Ok("User seccesfully created\n" + json);
            }
            return BadRequest();  
        }

        [Route("api/Update")]
        [HttpPut]
        public async Task<IActionResult> Update(string jsonString)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            UserDTO userDTOQ = JsonSerializer.Deserialize<UserDTO>(jsonString, options);

            var userQ = await _userService.Get().FirstOrDefaultAsync(x => x.Email == userDTOQ.Email);
            if (userQ != null) 
            {
                UserDTO user = new UserDTO()
                {
                    Email = userQ.Email,
                    NickName = userDTOQ.NickName,
                    Comments = userDTOQ.Comments
                };
                await _userService.Update(user);
                return Ok("User updated seccesfully");

            }
            return BadRequest("User not found");
        }

        [Route("/api/Delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string jsonString)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            UserDTO userDTOQ = JsonSerializer.Deserialize<UserDTO>(jsonString, options);

            var userQ = await _userService.Get().FirstOrDefaultAsync(x => x.Email == userDTOQ.Email);
            if (userQ != null)
            {
                UserDTO user = new UserDTO()
                {
                    Id = userQ.Id,
                    Email = userQ.Email,
                    NickName = userQ.NickName,
                    Comments = userQ.Comments,
                    CreateDate = userQ.CreateDate,
                };
                await _userService.Delete(user);
                return Ok("user deleted seccesfully");
            }
            return BadRequest("User not found");
        }
    }
}
