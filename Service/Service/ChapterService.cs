 using Repository.Interfaces;
using Service.Interfaces;
using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ChapterService : IChapterService
    {
        private readonly IChapterRepository _chapterRepo;

        public ChapterService(IChapterRepository chapterRepo)
        {
            _chapterRepo = chapterRepo;
        }

        public async Task<List<Chapter>> GetAllChaptersAsync()
        {
            var chapters = await _chapterRepo.GetAllAsync();
            return chapters;

        }
    }
}
