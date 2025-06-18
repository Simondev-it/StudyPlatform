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
        private readonly IUnitOfWork _unitOfWork;

        public ChapterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Chapter>> GetAllChaptersAsync()
        {
            var chapters = await _unitOfWork.ChapterRepository.GetAllAsync();
            return chapters;

        }
    }
}
