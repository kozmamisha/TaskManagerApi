using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.Repositories
{
    public interface IUsersRepository
    {
        Task Add(UserEntity user);
        Task<UserEntity> GetByEmail(string email);
    }
}
