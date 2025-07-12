using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyPlatform.Models;

namespace Repository.Interfaces;

public interface IQuestionRepository
{
    Task<Question> Add(Question question);
    Task<bool> Delete(int questionId);
    Task<bool> Update(Question question);
    Task<Question?> GetByIdAsync(int id);
}
