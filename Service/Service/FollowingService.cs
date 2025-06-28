using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using Service.Interfaces;
using StudyPlatform.Models;

namespace Service.Service;

public class FollowingService : IFollowingService
{
    private readonly IUnitOfWork _unitOfWork;

    public FollowingService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Following> CreateAsync(Following following)
    {
        return await _unitOfWork.FollowingRepository.CreateAsync(following);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _unitOfWork.FollowingRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Following>> GetByUserIdAsync(int userId)
    {
        return await _unitOfWork.FollowingRepository.GetByUserIdAsync(userId);
    }

    public async Task<bool> HasUserFollowedAsync(int userId, int followingId)
    {
        return await _unitOfWork.FollowingRepository.HasUserFollowedAsync(userId, followingId);
    }
}
