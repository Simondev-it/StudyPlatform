using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using StudyPlatform.Models;

namespace Repository.Repositories;

public class ProgressRepository : IProgressRepository
{
    private readonly StudyPlatformContext _context;

    public ProgressRepository(StudyPlatformContext context)
    {
        _context = context;
    }

    public async Task<Progress> AddAsync(Progress progress)
    {
        _context.Progresses.Add(progress);
        await _context.SaveChangesAsync();
        return progress;
    }

    public async Task<bool> DeleteAsync(int progressId)
    {
        var progress = await _context.Progresses.FindAsync(progressId);
        if (progress == null) return false;

        _context.Progresses.Remove(progress);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Progress?> GetByBoughtSubjectIdAsync(int boughtSubjectId)
    {
        return await _context.Progresses
            .FirstOrDefaultAsync(p => p.BoughtSubjectId == boughtSubjectId);
    }

    public async Task<bool> UpdateAsync(Progress progress)
    {
        var existingProgress = await _context.Progresses.FindAsync(progress.Id);
        if (existingProgress == null) return false;
        existingProgress.Chapter = progress.Chapter;
        existingProgress.Topic = progress.Topic;
        _context.Progresses.Update(existingProgress);
        return await _context.SaveChangesAsync() > 0;
    }
}
