using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.Entities
{
    public class User
    {
        private User() { }
        public User(Guid id, string username, string email, string password)
        {
            Id = id;
            UserName = username;
            Email = email;
            PasswordHash = password;
        }

        public Guid Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public static User Create(Guid id, string username, string email, string password)
        {
            return new User(id, username, email, password);
        }
    }
}
