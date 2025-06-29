using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyPlatform.Models;

namespace Service.Interfaces;

public interface IAccomplishAchievementService
{
    Task<AccomplishAchievement?> GetByIdAsync(int id);
    Task<IEnumerable<AccomplishAchievement>> GetByUserIdAsync(int userId);
    Task<AccomplishAchievement> AddAsync(AccomplishAchievement accomplishAchievement);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateAsync(AccomplishAchievement accomplishAchievement);
    Task<bool> HasUserAccomplishedAsync(int userId, int achievementId);
}
