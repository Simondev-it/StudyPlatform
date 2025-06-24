using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ISubjectRepository : IGenericRepository<Subject>
    {
        public Task<List<Subject>> GetAllSubjects();
        public Task<Subject> GetSubjectsById(int id);
    }
}
