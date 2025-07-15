using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TaskManager.BusinessLogic.Interfaces;
using TaskManagerApi.Authorization;
using TaskManagerApi.Contracts.Users;

namespace TaskManagerApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController(IUsersService usersService, IOptions<AuthOptions> options) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserRequest request)
        {
            await usersService.Register(request.UserName, request.Email, request.Password);

            return Created();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserRequest request)
        {
            var token = await usersService.Login(request.Email, request.Password);

            HttpContext.Response.Cookies.Append(options.Value.CookieName, token);

            return Created();
        }
    }
}
