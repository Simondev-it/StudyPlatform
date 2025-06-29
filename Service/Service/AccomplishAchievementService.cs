using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using Service.Interfaces;
using StudyPlatform.Models;

namespace Service.Service;

public class AccomplishAchievementService : IAccomplishAchievementService
{
    private readonly IUnitOfWork _unitOfWork;

    public AccomplishAchievementService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AccomplishAchievement> AddAsync(AccomplishAchievement accomplishAchievement)
    {
        accomplishAchievement.AchieveDate = DateOnly.FromDateTime(DateTime.UtcNow);
        return await _unitOfWork.AccomplishAchievementRepository.AddAsync(accomplishAchievement);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _unitOfWork.AccomplishAchievementRepository.DeleteAsync(id);
    }

    public async Task<AccomplishAchievement?> GetByIdAsync(int id)
    {
        return await _unitOfWork.AccomplishAchievementRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<AccomplishAchievement>> GetByUserIdAsync(int userId)
    {
        return await _unitOfWork.AccomplishAchievementRepository.GetByUserIdAsync(userId);
    }

    public async Task<bool> HasUserAccomplishedAsync(int userId, int achievementId)
    {
        return await _unitOfWork.AccomplishAchievementRepository.HasUserAccomplishedAsync(userId, achievementId);
    }

    public async Task<bool> UpdateAsync(AccomplishAchievement accomplishAchievement)
    {
        return await _unitOfWork.AccomplishAchievementRepository.UpdateAsync(accomplishAchievement);
    }
}
