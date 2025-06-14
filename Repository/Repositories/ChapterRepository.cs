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
    public class ChapterRepository : GenericRepository<Chapter>, IChapterRepository
    {
        private readonly StudyPlatformContext _context;

        public ChapterRepository(StudyPlatformContext context) : base(context)
        {
            _context = context;
        }

         

         
    }
}
