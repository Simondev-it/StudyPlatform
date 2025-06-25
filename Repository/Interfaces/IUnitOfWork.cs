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
        Task<int> SaveChangeAsync();


    }
}
