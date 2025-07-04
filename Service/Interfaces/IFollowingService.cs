﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyPlatform.Models;

namespace Service.Interfaces;

public interface IFollowingService
{
    Task<IEnumerable<Following>> GetByUserIdAsync(int userId);
    Task<Following> CreateAsync(Following following);
    Task<bool> DeleteAsync(int id);
    Task<bool> HasUserFollowedAsync(int userId, int followingId);
}
