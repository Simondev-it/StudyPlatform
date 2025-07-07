using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using StudyPlatform.Models;

namespace Repository.Repositories;

public class FollowingRepository : IFollowingRepository
{
    private readonly StudyPlatformContext _context;

    public FollowingRepository(StudyPlatformContext context)
    {
        _context = context;
    }

    public async Task<Following> CreateAsync(Following following)
    {
        following.FollowDate = DateOnly.FromDateTime(DateTime.Now);
        _context.Followings.Add(following);
        await _context.SaveChangesAsync();
        return following;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var following = await _context.Followings.FindAsync(id);
        if (following == null) return false;

        _context.Followings.Remove(following);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Following>> GetByFollowingIdAsync(int followingId)
    {
        return await _context.Followings
            .Where(f => f.FollowingId == followingId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Following>> GetByUserIdAsync(int userId)
    {
        return await _context.Followings
            .Where(f => f.UserId == userId)
            .ToListAsync();
    }

    public Task<bool> HasUserFollowedAsync(int userId, int followingId)
    {
        return _context.Followings
            .AnyAsync(f => f.UserId == userId && f.FollowingId == followingId);
    }
}
