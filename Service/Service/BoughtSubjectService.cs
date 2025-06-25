using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using Service.Interfaces;
using StudyPlatform.Models;

namespace Service.Service;

public class BoughtSubjectService : IBoughtSubjectService
{
    private readonly IUnitOfWork _unitOfWork;

    public BoughtSubjectService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BoughtSubject> AddAsync(BoughtSubject boughtSubject)
    {
        return await _unitOfWork.BoughtSubjectRepository.AddAsync(boughtSubject);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _unitOfWork.BoughtSubjectRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<BoughtSubject>> GetAllAsync()
    {
        return await _unitOfWork.BoughtSubjectRepository.GetAllAsync();
    }

    public async Task<BoughtSubject?> GetByIdAsync(int id)
    {
        return await _unitOfWork.BoughtSubjectRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<BoughtSubject>> GetByUserIdAsync(int userId)
    {
        return await _unitOfWork.BoughtSubjectRepository.GetByUserIdAsync(userId);
    }

    public async Task<bool> HasUserBoughtSubjectAsync(int userId, int subjectId)
    {
        return await _unitOfWork.BoughtSubjectRepository.HasUserBoughtSubjectAsync(userId, subjectId);
    }

    public async Task<bool> UpdateFeedbackAsync(int id, string feedback)
    {
        return await _unitOfWork.BoughtSubjectRepository.UpdateFeedbackAsync(id, feedback);
    }
}
