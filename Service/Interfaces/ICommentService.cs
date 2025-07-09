using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyPlatform.Models;

namespace Service.Interfaces;

public interface ICommentService
{
    Task<IEnumerable<Comment>> GetAllAsync();
    Task<Comment?> GetByIdAsync(int id);
    Task<IEnumerable<Comment>> GetByQuestionIdAsync(int questionId);
    Task<Comment> CreateAsync(Comment comment);
    Task<bool> UpdateAsync(Comment comment);
    Task<bool> DeleteAsync(int id);
}
