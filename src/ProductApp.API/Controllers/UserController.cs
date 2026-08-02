using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Common.Dtos;
using ProductApp.Application.Common.Interfaces;

namespace ProductApp.API.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("login/{phoneNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> Login(string phoneNumber)
        {
            var user = await _userService.LoginAsync(phoneNumber);
            if (user == null)
            {
                return NotFound(new { Message = "User not registered." });
            }
            return Ok(user);
        }
    }
}
