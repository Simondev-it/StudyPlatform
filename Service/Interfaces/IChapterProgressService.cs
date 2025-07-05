using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyPlatform.Models;

namespace Service.Interfaces;

public interface IChapterProgressService
{
    Task<ChapterProgress> CreateAsync(ChapterProgress chapterProgress);
    Task<List<ChapterProgress>> GetAllAsync();
    Task<ChapterProgress?> GetByIdAsync(int id);
    Task<bool> UpdateAsync(ChapterProgress chapterProgress);
}
