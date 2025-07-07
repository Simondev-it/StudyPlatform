using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyPlatform.Models;

namespace Repository.Interfaces;

public interface IFollowingRepository
{
    Task<IEnumerable<Following>> GetByUserIdAsync(int userId);
    Task<IEnumerable<Following>> GetByFollowingIdAsync(int followingId);
    Task<Following> CreateAsync(Following following);
    Task<bool> DeleteAsync(int id);
    Task<bool> HasUserFollowedAsync(int userId, int followingId);
}
