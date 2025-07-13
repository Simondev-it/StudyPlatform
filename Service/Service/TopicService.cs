using Repository.Interfaces;
using Service.Interfaces;
using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class TopicService : ITopicService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TopicService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Topic> CreateTopicAsync(Topic topic)
        {
            await _unitOfWork.TopicRepository.CreateAsync(topic);
            return topic;
        }

        public async Task<bool> DeleteTopicAsync(int id)
        {
            await _unitOfWork.TopicRepository.DeleteAsync(id);
            return true;
        }

        public async Task<List<Topic>> GetAllTopicsAsync()
        {
            var chapters = await _unitOfWork.TopicRepository.GetAllAsync();
            return chapters;

        }

        public async Task<Topic> GetTopicsByIdAsync(int id)
        {
            var chapters = await _unitOfWork.TopicRepository.GetTopicById(id);
            return chapters;

        }

        public async Task<bool> UpdateTopicAsync(Topic topic)
        {
            await _unitOfWork.TopicRepository.UpdateAsync(topic);
            return true;
        }
    }
}
