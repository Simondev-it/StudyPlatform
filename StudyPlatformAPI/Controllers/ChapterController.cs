using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Service;
using StudyPlatformAPI.DTOs.ChapterDto;
using StudyPlatformAPI.DTOs.TopicProgress;

namespace StudyPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    public class ChapterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IChapterService _chapterService;

        public ChapterController(IMapper mapper, IChapterService chapterService)
        {
            _mapper = mapper;
            _chapterService = chapterService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var result = await _chapterService.GetAllChaptersAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var chapter = await _chapterService.GetByIdAsync(id);

            if (chapter == null)
            {
                return NotFound();
            }

            var chapterDto = _mapper.Map<ChapterResponseDto>(chapter);

            return Ok(chapterDto);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateChapterDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Chapter data is null.");
            }

            var chapter = _mapper.Map<StudyPlatform.Models.Chapter>(dto);
            var createdChapter = await _chapterService.CreateAsync(chapter);

            if (createdChapter == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating chapter.");
            }

            var createdChapterDto = _mapper.Map<ChapterResponseDto>(createdChapter);
            return CreatedAtAction(nameof(GetById), new { id = createdChapter.Id }, createdChapterDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateChapter(int id, [FromBody] CreateChapterDto dto)
        {
            var existingChapter = await _chapterService.GetByIdAsync(id);
            if (existingChapter == null)
            {
                return NotFound();
            }

            // Map the DTO to the existing TopicProgress entity
            _mapper.Map(dto, existingChapter);


            var result = await _chapterService.UpdateAsync(existingChapter);
            if (!result)
            {
                return BadRequest("Failed to update chapter.");
            }

            return Ok(_mapper.Map<ChapterResponseDto>(existingChapter));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingChapter = await _chapterService.GetByIdAsync(id);
            if (existingChapter == null)
            {
                return NotFound();
            }

            var result = await _chapterService.DeleteAsync(id);
            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting chapter.");
            }

            return NoContent();
        }
    }
}
