using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SubjectRepository : GenericRepository<Subject, int>, ISubjectRepository
    {
        private readonly StudyPlatformContext _context;

        public SubjectRepository(StudyPlatformContext context) : base(context)
        {
            _context = context;
        }


        public async Task<List<Subject>> GetAllSubjects()
        {
            return await _context.Subjects
                .Include(s => s.Chapters)
                .ThenInclude(c => c.Topics)
                .ToListAsync();
        }

        public async Task<Subject> GetSubjectsById(int id)
        {
            return await _context.Subjects
                .Include(s => s.Chapters)
                .ThenInclude(c => c.Topics)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

    }
}

