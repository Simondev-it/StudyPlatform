using Microsoft.EntityFrameworkCore.Diagnostics;
using Repository.Interfaces;
using Repository.Repositories;
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
        private readonly IBoughtSubjectRepository _boughtSubjectRepository;
        private readonly IProgressRepository _progressRepository;
        private readonly ITopicProgressRepository _topicProgressRepository;
        private readonly IUserRepository _userProgressRepository;
        private readonly IFollowingRepository _followingRepository;
        private readonly IAchievementRepository _achievementRepository;
        private readonly IAccomplishAchievementRepository _accomplishmentAchievementRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IChapterProgressRepository _chapterProgressRepository;
        private readonly IQuestionRepository _questionRepository;

        public UnitOfWork(StudyPlatformContext context, IChapterRepository chapterRepository, ISubjectRepository subjectRepository, ITopicRepository topicRepository, IBoughtSubjectRepository boughtSubjectRepository, IProgressRepository progressRepository, ITopicProgressRepository topicProgressRepository, IUserRepository userProgressRepository, IFollowingRepository followingRepository, IAchievementRepository achievementRepository, IAccomplishAchievementRepository accomplishmentAchievementRepository, ICommentRepository commentRepository, IChapterProgressRepository chapterProgressRepository, IQuestionRepository questionRepository)
        {
            _context = context;
            _chapterRepository = chapterRepository;
            _subjectRepository = subjectRepository;
            _topicRepository = topicRepository;
            _boughtSubjectRepository = boughtSubjectRepository;
            _progressRepository = progressRepository;
            _topicProgressRepository = topicProgressRepository;
            _userProgressRepository = userProgressRepository;
            _followingRepository = followingRepository;
            _achievementRepository = achievementRepository;
            _accomplishmentAchievementRepository = accomplishmentAchievementRepository;
            _commentRepository = commentRepository;
            _chapterProgressRepository = chapterProgressRepository;
            _questionRepository = questionRepository;
        }

        public IChapterRepository ChapterRepository => _chapterRepository;
        public ISubjectRepository SubjectRepository => _subjectRepository;
        public ITopicRepository TopicRepository => _topicRepository;
        public IBoughtSubjectRepository BoughtSubjectRepository => _boughtSubjectRepository;
        public IProgressRepository ProgressRepository => _progressRepository;
        public ITopicProgressRepository TopicProgressRepository => _topicProgressRepository;
        public IUserRepository UserRepository => _userProgressRepository;
        public IFollowingRepository FollowingRepository => _followingRepository;
        public IAchievementRepository AchievementRepository => _achievementRepository;
        public IAccomplishAchievementRepository AccomplishAchievementRepository => _accomplishmentAchievementRepository;
        public ICommentRepository CommentRepository => _commentRepository;
        public IChapterProgressRepository ChapterProgressRepository => _chapterProgressRepository;
        public IQuestionRepository QuestionRepository => _questionRepository;

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
