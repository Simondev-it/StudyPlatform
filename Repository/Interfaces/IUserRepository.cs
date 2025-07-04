﻿using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        public Task<User?> GetUserByEmailAsync(string email);

        public Task<User?> GetUserByUsernameAsync(string username);
    }
}
