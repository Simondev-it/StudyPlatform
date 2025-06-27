using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace StudyPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
         

        
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _subjectService.GetAllSubjects();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            var result = await _subjectService.GetSubjectByID(id);
            return Ok(result);
        }
    }
}
