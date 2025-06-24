using Repository.Interfaces;
using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyPlatform
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudyPlatformContext _context;
        private readonly IChapterRepository _chapterRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITopicRepository _topicRepository;



        public UnitOfWork(StudyPlatformContext context, IChapterRepository chapterRepository, ISubjectRepository subjectRepository, ITopicRepository topicRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _chapterRepository = chapterRepository ?? throw new ArgumentNullException(nameof(chapterRepository));
            _subjectRepository = subjectRepository ?? throw new ArgumentNullException(nameof(subjectRepository));
            _topicRepository = topicRepository ?? throw new ArgumentNullException(nameof(topicRepository));
        }

        public IChapterRepository ChapterRepository => _chapterRepository;
        public ISubjectRepository SubjectRepository => _subjectRepository;

        public ITopicRepository TopicRepository => _topicRepository;
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
