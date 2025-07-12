 using Repository.Interfaces;
using Service.Interfaces;
using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service;

public class ChapterService : IChapterService 
{
    private readonly IUnitOfWork _unitOfWork;

    public ChapterService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Chapter> CreateAsync(Chapter chapter)
    {
       await _unitOfWork.ChapterRepository.CreateAsync(chapter);
        return chapter;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await _unitOfWork.ChapterRepository.DeleteAsync(id);
        return true;
    }

    public async Task<List<Chapter>> GetAllChaptersAsync()
    {
        var chapters = await _unitOfWork.ChapterRepository.GetAllAsync();
        return chapters;

    }
    public Task<Chapter?> GetByIdAsync(int id)
    {
        return _unitOfWork.ChapterRepository.GetByIdAsync(id);
    }

    public async Task<bool> UpdateAsync(Chapter chapter)
    {
       await _unitOfWork.ChapterRepository.UpdateAsync(chapter);
        return true;
    }
}
