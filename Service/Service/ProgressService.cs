using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using Service.Interfaces;
using StudyPlatform.Models;

namespace Service.Service;

public class ProgressService : IProgressService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProgressService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Progress> AddAsync(Progress progress)
    {
        return await _unitOfWork.ProgressRepository.AddAsync(progress);
    }

    public async Task<bool> DeleteAsync(int progressId)
    {
        return await _unitOfWork.ProgressRepository.DeleteAsync(progressId);
    }

    public async Task<Progress?> GetByBoughtSubjectIdAsync(int boughtSubjectId)
    {
        return await _unitOfWork.ProgressRepository.GetByBoughtSubjectIdAsync(boughtSubjectId);
    }

    public async Task<Progress?> GetByIdAsync(int id)
    {
        return await _unitOfWork.ProgressRepository.GetByIdAsync(id);
    }

    public async Task<bool> UpdateAsync(Progress progress)
    {
        return await _unitOfWork.ProgressRepository.UpdateAsync(progress);
    }
}
