using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using Service.Interfaces;
using StudyPlatform.Models;

namespace Service.Service;

public class ChapterProgressService : IChapterProgressService
{
    private readonly IUnitOfWork _unitOfWork;

    public ChapterProgressService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ChapterProgress> CreateAsync(ChapterProgress chapterProgress)
    {
        return await _unitOfWork.ChapterProgressRepository.CreateAsync(chapterProgress);
    }

    public Task<List<ChapterProgress>> GetAllAsync()
    {
        return _unitOfWork.ChapterProgressRepository.GetAllAsync();
    }

    public Task<ChapterProgress?> GetByIdAsync(int id)
    {
        return _unitOfWork.ChapterProgressRepository.GetByIdAsync(id);
    }

    public async Task<bool> UpdateAsync(ChapterProgress chapterProgress)
    {
        return await _unitOfWork.ChapterProgressRepository.UpdateAsync(chapterProgress);
    }
}
