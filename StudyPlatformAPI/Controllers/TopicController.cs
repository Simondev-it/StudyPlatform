using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace StudyPlatformAPI.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet("topic")]
        public async Task<IActionResult> Get()
        {
            var result = await _topicService.GetAllTopicsAsync();
            return Ok(result);
        }
    }
}
