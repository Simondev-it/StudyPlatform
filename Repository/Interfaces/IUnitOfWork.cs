using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IChapterRepository ChapterRepository { get; }
        public ISubjectRepository SubjectRepository { get; }

        public ITopicRepository TopicRepository { get; }
        public IBoughtSubjectRepository BoughtSubjectRepository { get; }
        public IProgressRepository ProgressRepository { get; }
        public ITopicProgressRepository TopicProgressRepository { get; }
        public IUserRepository UserRepository { get; }
        public IFollowingRepository FollowingRepository { get; }
        public IAchievementRepository AchievementRepository { get; }
        public IAccomplishAchievementRepository AccomplishAchievementRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public IChapterProgressRepository ChapterProgressRepository { get; }
        public IQuestionRepository QuestionRepository { get; }
        Task<int> SaveChangeAsync();


    }
}
