using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsersAsync();

        public Task<User?> GetUserByIdAsync(int id);

        public Task<User> CreateUserAsync(User user);

        public Task<bool> UpdateUserAsync(User user);

    }
}
