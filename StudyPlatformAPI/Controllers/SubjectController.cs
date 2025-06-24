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
         

        
        [HttpGet("subject/getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _subjectService.GetAllSubjects();
            return Ok(result);
        }
    }
}
