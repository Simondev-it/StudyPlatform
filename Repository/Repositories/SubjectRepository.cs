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

        public async Task<Subject> AddSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<bool> DeleteSubject(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null) return false;
            _context.Subjects.Remove(subject);
            return await _context.SaveChangesAsync() > 0;
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

        public async Task<bool> UpdateSubject(Subject subject)
        {
            var existingSubject = await _context.Subjects.FindAsync(subject.Id);
            if (existingSubject == null) return false;
            existingSubject.Name = subject.Name;
            existingSubject.Price = subject.Price;
            existingSubject.Image = subject.Image;
            existingSubject.LastEditDate = DateOnly.FromDateTime(DateTime.Now);
            _context.Subjects.Update(existingSubject);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

