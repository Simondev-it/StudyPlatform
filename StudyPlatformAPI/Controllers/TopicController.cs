using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Service;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.ChapterDto;
using StudyPlatformAPI.DTOs.TopicDto;

namespace StudyPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;


        public TopicController(ITopicService topicService, IMapper mapper)
        {
            _topicService = topicService;
            _mapper = mapper;
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

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] TopicCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Topic data is null.");
            }

            var topic = _mapper.Map<Topic>(dto);
            var createdTopic = await _topicService.CreateTopicAsync(topic);

            if (createdTopic == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating topic.");
            }

            var createdTopicDto = _mapper.Map<TopicResponseDto>(createdTopic);
            return CreatedAtAction(nameof(GetTopicById), new { id = createdTopic.Id }, createdTopicDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateChapter(int id, [FromBody] TopicCreateDto dto)
        {
            var existingTopic = await _topicService.GetTopicsByIdAsync(id);
            if (existingTopic == null)
            {
                return NotFound();
            }

            // Map the DTO to the existing TopicProgress entity
            _mapper.Map(dto, existingTopic);


            var result = await _topicService.UpdateTopicAsync(existingTopic);
            if (!result)
            {
                return BadRequest("Failed to update chapter.");
            }

            return Ok(_mapper.Map<TopicResponseDto>(existingTopic));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingTopic = await _topicService.GetTopicsByIdAsync(id);
            if (existingTopic == null)
            {
                return NotFound();
            }

            var result = await _topicService.DeleteTopicAsync(id);
            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting chapter.");
            }

            return NoContent();
        }
    }
}
