using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        private readonly StudyPlatformContext _context;

        public UserRepository(StudyPlatformContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void UpdatePassword(User user, string newPassword)
        {
            // Có thể hash tại đây nếu muốn
            user.Password = newPassword;
            _context.Entry(user).Property(x => x.Password).IsModified = true;
        }
    }
}
