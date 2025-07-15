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
        public async Task<IResult> Register(RegisterUserRequest request)
        {
            await usersService.Register(request.UserName, request.Email, request.Password);

            return Results.Ok();
        }

        [HttpPost("login")]
        public async Task<IResult> Login([FromBody] LoginUserRequest request)
        {
            var token = await usersService.Login(request.Email, request.Password);

            HttpContext.Response.Cookies.Append(options.Value.CookieName, token);

            return Results.Ok();
        }
    }
}
