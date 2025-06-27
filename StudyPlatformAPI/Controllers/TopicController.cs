using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace StudyPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var result = await _topicService.GetAllTopicsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopicById(int id)
        {
            var result = await _topicService.GetTopicsByIdAsync(id);
            return Ok(result);
        }
    }
}
