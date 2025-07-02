using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using StudyPlatformAPI.DTOs.ChapterDto;

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
    }
}
