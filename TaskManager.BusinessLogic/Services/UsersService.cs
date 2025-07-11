using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BusinessLogic.Interfaces;
using TaskManager.DataAccess.Entities;
using TaskManager.DataAccess.Enums;
using TaskManager.DataAccess.Repositories;

namespace TaskManager.BusinessLogic.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;
        public UsersService(
            IUsersRepository userRepository,
            IPasswordHasher passwordHasher,
            IJwtProvider jwtProvider
        )
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }
        public async Task Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var newUser = new UserEntity
            {
                Id = new Guid(),
                UserName = userName,
                PasswordHash = hashedPassword,
                Email = email,
            };

            await _userRepository.Add(newUser);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result == false)
            {
                throw new Exception("Invalid email or password.");
            }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }
    }
}
