using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyPlatform.Models;

namespace Repository.Interfaces;

public interface IBoughtSubjectRepository
{
    Task<IEnumerable<BoughtSubject>> GetAllAsync();
    Task<BoughtSubject?> GetByIdAsync(int id);
    Task<IEnumerable<BoughtSubject>> GetByUserIdAsync(int userId);
    Task<BoughtSubject> AddAsync(BoughtSubject boughtSubject);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateFeedbackAsync(int id, BoughtSubject boughtSubject);
    Task<bool> HasUserBoughtSubjectAsync(int userId, int subjectId);
}
