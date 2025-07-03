using System.Security.Cryptography.X509Certificates;
using TaskManager.BusinessLogic.Interfaces;

namespace TaskManagerApi.Authorization
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string hashedPassword) => 
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}
