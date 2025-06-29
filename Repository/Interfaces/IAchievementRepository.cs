using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyPlatform.Models;

namespace Repository.Interfaces;

public interface IAchievementRepository
{
    Task<IEnumerable<Achievement>> GetAllAsync();
    Task<Achievement?> GetByIdAsync(int id);
}
