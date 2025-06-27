using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Service;
using StudyPlatform.Models;

namespace StudyPlatformAPI.Controllers
{
    public class TopicProgressController : ControllerBase
    {
        private readonly ITopicProgressService _topicProgressService;

        public TopicProgressController(ITopicProgressService topicProgressService)
        {
            _topicProgressService = topicProgressService;
        }

        [HttpPost("topicProgress")]
        public async Task<IActionResult> CreatTopicProgress(TopicProgress topicProgress)
        {
            var result = await _topicProgressService.CreateTopicProgressAsync(topicProgress);
            return Ok(result);
        }
    }
}
