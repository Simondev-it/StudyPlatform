using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.SubjectDto;

namespace StudyPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISubjectService _subjectService;

        public SubjectController(IMapper mapper, ISubjectService subjectService)
        {
            _mapper = mapper;
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

        [HttpPost]
        public async Task<IActionResult> AddSubject([FromBody] CreateSubjectDto dto)
        {
            var subject = _mapper.Map<Subject>(dto);
            var createdSubject = await _subjectService.AddSubject(subject);
            if (createdSubject == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating subject.");
            }
            var createdSubjectDto = _mapper.Map<SubjectResponseDto>(createdSubject);
            return CreatedAtAction(nameof(GetSubjectById), new { id = createdSubject.Id }, createdSubjectDto);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateSubject(int id, [FromBody] PatchSubjectDto dto)
        {
            var existingSubject = await _subjectService.GetSubjectByID(id);
            if (existingSubject == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, existingSubject);
            var result = await _subjectService.UpdateSubject(existingSubject);
            if (!result) return StatusCode(500, "Update failed.");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var result = await _subjectService.DeleteSubject(id);
            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting subject.");
            }
            return NoContent();
        }
    }
}
