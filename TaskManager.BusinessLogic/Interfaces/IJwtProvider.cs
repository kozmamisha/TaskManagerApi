using TaskManager.DataAccess.Entities;

namespace TaskManager.BusinessLogic.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(UserEntity user);
    }
}