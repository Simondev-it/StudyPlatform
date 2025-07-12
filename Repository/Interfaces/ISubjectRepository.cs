using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ISubjectRepository : IGenericRepository<Subject, int>
    {
        public Task<List<Subject>> GetAllSubjects();
        public Task<Subject> GetSubjectsById(int id);
        public Task<Subject> AddSubject(Subject subject);
        public Task<bool> UpdateSubject(Subject subject);
        public Task<bool> DeleteSubject(int id);
    }
}
