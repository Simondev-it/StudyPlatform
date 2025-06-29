using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using StudyPlatform.Models;

namespace Repository.Repositories;

public class AchievementRepository : IAchievementRepository
{
    private readonly StudyPlatformContext _context;

    public AchievementRepository(StudyPlatformContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Achievement>> GetAllAsync()
    {
        return await _context.Achievements.ToListAsync();
    }

    public async Task<Achievement?> GetByIdAsync(int id)
    {
        return await _context.Achievements
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
