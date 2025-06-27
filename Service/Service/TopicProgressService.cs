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
    public class TopicProgressService : ITopicProgressService
    {

        private readonly IUnitOfWork _unitOfWork;

        public TopicProgressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TopicProgress> CreateTopicProgressAsync(TopicProgress topicProgress)
        {
             return await _unitOfWork.TopicProgressRepository.CreateAsync(topicProgress);
        }

        public async Task<List<TopicProgress>> GetAllTopicProgressAsync()
        {
            return await _unitOfWork.TopicProgressRepository.GetAllAsync();
        }

        public async Task<TopicProgress?> GetTopicProgressByIdAsync(int id)
        {
            return await _unitOfWork.TopicProgressRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateTopicProgressAsync(TopicProgress topicProgress)
        {
            return await _unitOfWork.TopicProgressRepository.UpdateAsync(topicProgress);
        }


    }
}
