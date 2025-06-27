using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Service;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.BoughtSubject;
using StudyPlatformAPI.DTOs.TopicProgress;

namespace StudyPlatformAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TopicProgressController : ControllerBase
    {
        private readonly ITopicProgressService _topicProgressService;
        private readonly IMapper _mapper;

        public TopicProgressController(ITopicProgressService topicProgressService, IMapper mapper)
        {
            _topicProgressService = topicProgressService;
            _mapper = mapper;
        }

        [HttpPost("")]
        public async Task<ActionResult> CreateTopicProgress(TopicProgressCreateDTO dto)
        {

            var topicProgress = _mapper.Map<TopicProgress>(dto);
            var result = await _topicProgressService.CreateTopicProgressAsync(topicProgress);
            return  Ok(_mapper.Map<TopicProgressResponseDTO>(result));
        }
    }
}
