using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using Service.Interfaces;
using StudyPlatform.Models;

namespace Service.Service;

public class AchievementService : IAchievementService
{
    private readonly IUnitOfWork _unitOfWork;

    public AchievementService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Achievement>> GetAllAsync()
    {
        return await _unitOfWork.AchievementRepository.GetAllAsync();
    }

    public async Task<Achievement?> GetByIdAsync(int id)
    {
        return await _unitOfWork.AchievementRepository.GetByIdAsync(id);
    }
}
