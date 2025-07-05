using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using StudyPlatform.Models;

namespace Repository.Repositories;

public class ChapterProgressRepository : GenericRepository<ChapterProgress, int>, IChapterProgressRepository
{
    private readonly StudyPlatformContext _context;

    public ChapterProgressRepository(StudyPlatformContext context) : base(context)
    {
        _context = context;
    }
}
