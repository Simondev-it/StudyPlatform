using Repository.Interfaces;
using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        private readonly StudyPlatformContext _context;

        public SubjectRepository(StudyPlatformContext context) : base(context)
        {
            _context = context;
        }
    }
}
