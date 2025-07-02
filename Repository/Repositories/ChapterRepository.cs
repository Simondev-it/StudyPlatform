using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ChapterRepository : GenericRepository<Chapter, int>, IChapterRepository
    {
        private readonly StudyPlatformContext _context;

        public ChapterRepository(StudyPlatformContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Chapter?> GetByIdAsync(int id)
        {
            return await _context.Chapters
                .Include(c => c.Topics)
                    .ThenInclude(t => t.Questions)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
