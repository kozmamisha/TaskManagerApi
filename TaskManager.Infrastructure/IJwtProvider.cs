using TaskManager.DataAccess.Entities;

namespace TaskManager.Infrastructure
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}