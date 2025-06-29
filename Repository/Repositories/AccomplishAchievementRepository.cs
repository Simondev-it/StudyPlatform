using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using StudyPlatform.Models;

namespace Repository.Repositories;

public class AccomplishAchievementRepository : IAccomplishAchievementRepository
{
    private readonly StudyPlatformContext _context;

    public AccomplishAchievementRepository(StudyPlatformContext context)
    {
        _context = context;
    }

    public async Task<AccomplishAchievement> AddAsync(AccomplishAchievement accomplishAchievement)
    {
        _context.AccomplishAchievements.Add(accomplishAchievement);
        await _context.SaveChangesAsync();
        return accomplishAchievement;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var achievement = await GetByIdAsync(id);
        if (achievement == null) return false;
        _context.AccomplishAchievements.Remove(achievement);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<AccomplishAchievement?> GetByIdAsync(int id)
    {
        return await _context.AccomplishAchievements
            .FindAsync(id);
    }

    public async Task<IEnumerable<AccomplishAchievement>> GetByUserIdAsync(int userId)
    {
        return await _context.AccomplishAchievements
            .Where(aa => aa.UserId == userId)
            .ToListAsync();
    }

    public Task<bool> HasUserAccomplishedAsync(int userId, int achievementId)
    {
        return _context.AccomplishAchievements
            .AnyAsync(aa => aa.UserId == userId && aa.AchievementId == achievementId);
    }

    public async Task<bool> UpdateAsync(AccomplishAchievement accomplishAchievement)
    {
        var existingAchievement = await _context.AccomplishAchievements.FindAsync(accomplishAchievement.Id);
        if (existingAchievement == null) return false;

        existingAchievement.Progress = accomplishAchievement.Progress;
        existingAchievement.AchieveDate = accomplishAchievement.AchieveDate;
        existingAchievement.Status = accomplishAchievement.Status;
        return await _context.SaveChangesAsync() > 0;
    }
}
