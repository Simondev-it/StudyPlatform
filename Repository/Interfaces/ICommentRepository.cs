using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyPlatform.Models;

namespace Repository.Interfaces;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetByQuestionIdAsync(int questionId);
    Task<Comment?> GetByIdAsync(int id);
    Task<Comment> CreateAsync(Comment comment);
    Task<bool> UpdateAsync(Comment comment);
    Task<bool> DeleteAsync(Comment comment);
}
