using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITopicProgressService
    {
        public Task<TopicProgress> CreateTopicProgressAsync(TopicProgress topicProgress);
        public Task<List<TopicProgress>> GetAllTopicProgressAsync();
        public Task<TopicProgress?> GetTopicProgressByIdAsync(int id);
        public Task<bool> UpdateTopicProgressAsync(TopicProgress topicProgress);
        
    }
}
