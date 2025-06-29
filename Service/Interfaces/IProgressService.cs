using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyPlatform.Models;

namespace Service.Interfaces;

public interface IProgressService
{
    Task<Progress?> GetByIdAsync(int id);
    Task<Progress?> GetByBoughtSubjectIdAsync(int boughtSubjectId);
    Task<bool> UpdateAsync(Progress progress);
    Task<Progress> AddAsync(Progress progress);
    Task<bool> DeleteAsync(int progressId);
}
