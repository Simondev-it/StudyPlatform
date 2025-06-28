using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using StudyPlatform.Models;

namespace Repository.Repositories;

public class BoughtSubjectRepository : IBoughtSubjectRepository
{
    private readonly StudyPlatformContext _context;

    public BoughtSubjectRepository(StudyPlatformContext context)
    {
        _context = context;
    }

    public async Task<BoughtSubject> AddAsync(BoughtSubject boughtSubject)
    {
        _context.BoughtSubjects.Add(boughtSubject);
        await _context.SaveChangesAsync();
        return boughtSubject;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var bought = await _context.BoughtSubjects.FindAsync(id);
        if (bought == null) return false;

        _context.BoughtSubjects.Remove(bought);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<BoughtSubject>> GetAllAsync()
    {
        return await _context.BoughtSubjects
                             .Include(bs => bs.Subject)
                             .Include(bs => bs.User)
                             .Include(bs => bs.Progress)
                             .ToListAsync();
    }

    public async Task<BoughtSubject?> GetByIdAsync(int id)
    {
        return await _context.BoughtSubjects
                             .Include(bs => bs.Subject)
                             .Include(bs => bs.User)
                             .Include(bs => bs.Progress)
                             .FirstOrDefaultAsync(bs => bs.Id == id);
    }

    public async Task<IEnumerable<BoughtSubject>> GetByUserIdAsync(int userId)
    {
        return await _context.BoughtSubjects
                             .Include(bs => bs.Subject)
                             .Include(bs => bs.Progress)
                             .Where(bs => bs.UserId == userId)
                             .ToListAsync();
    }

    public async Task<bool> HasUserBoughtSubjectAsync(int userId, int subjectId)
    {
        return await _context.BoughtSubjects
            .AnyAsync(bs => bs.UserId == userId && bs.SubjectId == subjectId);
    }

    public async Task<bool> UpdateFeedbackAsync(int id, string feedback)
    {
        var bought = await _context.BoughtSubjects.FindAsync(id);
        if (bought == null) return false;

        bought.Feedback = feedback;
        return await _context.SaveChangesAsync() > 0;
    }
}
