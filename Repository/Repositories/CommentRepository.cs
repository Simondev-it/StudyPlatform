using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using StudyPlatform.Models;

namespace Repository.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly StudyPlatformContext _context;

    public CommentRepository(StudyPlatformContext context)
    {
        _context = context;
    }

    public async Task<Comment> CreateAsync(Comment comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<bool> DeleteAsync(Comment comment)
    {
        _context.Comments.Remove(comment);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Comment>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _context.Comments
            .FindAsync(id);
    }

    public async Task<IEnumerable<Comment>> GetByQuestionIdAsync(int questionId)
    {
        return await _context.Comments
            .Where(c => c.QuestionId == questionId)
            .ToListAsync();
    }

    public async Task<bool> UpdateAsync(Comment comment)
    {
        _context.Comments.Update(comment);
        return await _context.SaveChangesAsync() > 0;
    }
}
