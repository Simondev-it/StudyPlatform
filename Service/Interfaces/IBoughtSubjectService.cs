using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyPlatform.Models;

namespace Service.Interfaces;

public interface IBoughtSubjectService
{
    Task<IEnumerable<BoughtSubject>> GetAllAsync();
    Task<BoughtSubject?> GetByIdAsync(int id);
    Task<IEnumerable<BoughtSubject>> GetByUserIdAsync(int userId);
    Task<BoughtSubject> AddAsync(BoughtSubject boughtSubject);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateFeedbackAsync(int id, string feedback);
    Task<bool> HasUserBoughtSubjectAsync(int userId, int subjectId);
}
