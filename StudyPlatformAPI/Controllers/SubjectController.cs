using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace StudyPlatformAPI.Controllers
{
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet("subject")]
        public async Task<IActionResult> Get()
        {
            var result = await _subjectService.GetAllSujectsAsync();
            return Ok(result);
        }
    }
}
