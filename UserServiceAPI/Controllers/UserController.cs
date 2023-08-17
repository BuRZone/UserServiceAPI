using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;
using UserServiceAPI.BLL.DTO;
using UserServiceAPI.BLL.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        [Route("api/Get")]
        [HttpGet]
        public async Task<IActionResult> Get(string email)
        {
            var userQ = await _userService.Get().FirstOrDefaultAsync(x => x.Email == email);
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
            return Ok("User not found");

        }
        [Route("api/Create")]
        [HttpPost]
        public async Task<IActionResult> Create(UserDTO userDTO)
        {
            var userQ = await _userService.Get().FirstOrDefaultAsync(x => x.Email == userDTO.Email);
            if (userQ != null)
            {
                return Ok("User allready exist");
            }
            await _userService.Create(userDTO);

            var userQuery  = await _userService.Get().FirstOrDefaultAsync(x => x.Email == userDTO.Email);
            if (userQuery != null)
            {
                return Ok("User seccesfully created");
            }
            return Ok("что то пошло не так");
            
        }
    }
}
