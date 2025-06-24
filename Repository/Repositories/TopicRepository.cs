using Repository.Interfaces;
using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class TopicRepository : GenericRepository<Topic>, ITopicRepository
    {

        private readonly StudyPlatformContext _context;

        public TopicRepository(StudyPlatformContext context) : base(context)
        {
            _context = context;
        }
    }
}
