//using TaskManager.BusinessLogic.Services;
//using TaskManagerApi.Contracts.Users;

//namespace TaskManagerApi.Endpoints
//{
//    public static class UsersEndpoint
//    {
//        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
//        {
//            var endpoints = app.MapGroup("api/auth");

//            endpoints.MapPost("register", Register);
//            endpoints.MapPost("login", Login);

//            return endpoints;
//        }

//        private static async Task<IResult> Register(RegisterUserRequest request, UsersService usersService)
//        {
//            await usersService.Register(request.UserName, request.Email, request.Password);

//            return Results.Ok();
//        }

//        private static async Task<IResult> Login(LoginUserRequest request, UsersService userService)
//        {
//            var token = await userService.Login(request.Email, request.Password);

//            return Results.Ok(token);
//        }
//    }
//}
