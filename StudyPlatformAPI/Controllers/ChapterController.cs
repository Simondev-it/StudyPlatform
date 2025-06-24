using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace StudyPlatformAPI.Controllers
{
    public class ChapterController : ControllerBase
    {

        private readonly IChapterService _chapterService;

        public ChapterController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        [HttpGet("chapter")]
        public async Task<IActionResult> Get()
        {
            var result = await _chapterService.GetAllChaptersAsync();
            return Ok(result);
        }
    }
}
