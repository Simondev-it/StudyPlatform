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

        //[HttpPost("")]
        //public async Task<ActionResult> CreateTopicProgress(TopicProgressCreateDTO dto)
        //{

        //    var topicProgress = _mapper.Map<TopicProgress>(dto);
        //    var result = await _topicProgressService.CreateTopicProgressAsync(topicProgress);
        //    return  Ok(_mapper.Map<TopicProgressResponseDTO>(result));
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTopicProgressById(int id)
        {
            var result = await _topicProgressService.GetTopicProgressByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TopicProgressResponseDTO>(result));
        }

        [HttpPut("{id}")]
        //public async Task<ActionResult> UpdateTopicProgress(int id, TopicProgressCreateDTO dto)
        //{
        //    var existingTopicProgress = await _topicProgressService.GetTopicProgressByIdAsync(id);
        //    if (existingTopicProgress == null)
        //    {
        //        return NotFound();
        //    }

        //    var updatedTopicProgress = _mapper.Map<TopicProgress>(dto);
        //    updatedTopicProgress.Id = id; // Ensure the ID is set for the update

        //    var result = await _topicProgressService.UpdateTopicProgressAsync(updatedTopicProgress);
        //    if (!result)
        //    {
        //        return BadRequest("Failed to update topic progress.");
        //    }

        //    return NoContent();
        //}

        public async Task<ActionResult> UpdateTopicProgress(int id, TopicProgressCreateDTO dto)
        {
            var existingTopicProgress = await _topicProgressService.GetTopicProgressByIdAsync(id);
            if (existingTopicProgress == null)
            {
                return NotFound();
            }

            // Map the DTO to the existing TopicProgress entity
            _mapper.Map(dto, existingTopicProgress);


            var result = await _topicProgressService.UpdateTopicProgressAsync(existingTopicProgress);
            if (!result)
            {
                return BadRequest("Failed to update topic progress.");
            }

            return Ok(_mapper.Map<TopicProgressResponseDTO>(existingTopicProgress));
        }

        //[HttpPost]
        //public async Task<ActionResult<TopicProgressResponseDTO>> CreateTopicProgress(TopicProgressCreateDTO dto)
        //{
        //    var topicProgress = _mapper.Map<TopicProgress>(dto);
        //    var result = await _topicProgressService.CreateTopicProgressAsync(topicProgress);
        //    return CreatedAtAction(nameof(GetTopicProgressById), new { id = result.Id }, _mapper.Map<TopicProgressResponseDTO>(result));


        //}

        [HttpPost("")]
        public async Task<ActionResult> CreateTopicProgress(TopicProgressCreateDTO dto)
        {

            var topicProgress = _mapper.Map<TopicProgress>(dto);
            topicProgress.StartDate = DateOnly.FromDateTime(DateTime.UtcNow);
            var result = await _topicProgressService.CreateTopicProgressAsync(topicProgress);
            return Ok(_mapper.Map<TopicProgressResponseDTO>(result));
        }
    }
}
