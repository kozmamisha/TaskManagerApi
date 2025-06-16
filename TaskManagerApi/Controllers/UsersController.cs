using Microsoft.AspNetCore.Mvc;
using TaskManager.BusinessLogic.Services;
using TaskManagerApi.Contracts.Users;

namespace TaskManagerApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController(IUsersService usersService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IResult> Register(RegisterUserRequest request)
        {
            await usersService.Register(request.UserName, request.Email, request.Password);

            return Results.Ok();
        }

        [HttpPost("login")]
        public async Task<IResult> Login(LoginUserRequest request)
        {
            var token = await usersService.Login(request.Email, request.Password);

            return Results.Ok(token);
        }
    }
}
