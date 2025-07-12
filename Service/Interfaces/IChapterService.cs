 using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IChapterService
    {
        Task<List<Chapter>> GetAllChaptersAsync();
        Task<Chapter?> GetByIdAsync(int id);

        Task<Chapter> CreateAsync(Chapter chapter);

        Task<bool> UpdateAsync(Chapter chapter);

        Task<bool> DeleteAsync(int id);
    }
}
