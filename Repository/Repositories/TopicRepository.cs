using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class TopicRepository : GenericRepository<Topic, int>, ITopicRepository
    {

        private readonly StudyPlatformContext _context;

        public TopicRepository(StudyPlatformContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Topic> GetTopicById(int id)
        {
            return await _context.Topics
                .Include(t => t.Questions)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
         
    }
}
