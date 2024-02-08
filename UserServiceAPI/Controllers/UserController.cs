using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserServiceAPI.BLL.Models;
using UserServiceAPI.BLL.Interfaces;
using System.Linq;
using System.Threading;
using System;

namespace UserServiceAPI.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("api/v1/List")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var userQ = await _userService.GetAllUsersAsync(cancellationToken);

            if (userQ.Count() == 0)
            {
                return NotFound("no User found");
            }
            if(userQ == null)
            {
                return StatusCode(500);
            }
            return Ok(userQ);
        }

        [Route("api/v1/Get/{email}")]
        [HttpGet]
        public async Task<IActionResult> GetUserByEmailAsync([FromRoute] string email, CancellationToken cancellationToken)
        {
            var userQ = (await _userService.GetAllUsersAsync(cancellationToken))
                .SingleOrDefault(x => x.Email == email);
            if (userQ == null)
            {
                return NotFound("User not found");
            }
            return Ok(userQ);

        }

        [Route("api/v1/Create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserDto createUserDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid == false)
            {
                return ValidationProblem(ModelState);
            }
            var result = await _userService.CreateUserAsync(createUserDto, cancellationToken);
            if(result == false)
            {
                return BadRequest($"User with email {createUserDto.Email} allready exist");
            }
            if (result == null)
            {
                return StatusCode(500);
            }
            return Ok("User created seccesfully");
        }

        [Route("api/v1/Update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserDto updateUserDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid == false)
            {
                return ValidationProblem(ModelState);
            }
            var result = await _userService.UpdateUserAsync(updateUserDto, cancellationToken);
            if (result == false)
            {
                return StatusCode(500);
            }
            return Ok("User updated seccesfully");
        }

        [Route("api/v1/Delete/{id:guid}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _userService.DeleteUserAsync(id, cancellationToken);
            if (result == false)
            {
                return NotFound($"The User with id {id} not found");
            }
            if(result == null)
            {
                return StatusCode(500);
            }
            return Ok("User deleted seccesfully");
        }
    }
}