using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs;

namespace StudyPlatformAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoughtSubjectController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IBoughtSubjectService _boughtSubjectService;

    public BoughtSubjectController(IMapper mapper, IBoughtSubjectService boughtSubjectService)
    {
        _mapper = mapper;
        _boughtSubjectService = boughtSubjectService;
    }

    // GET: api/BoughtSubject
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var boughtSubjects = await _boughtSubjectService.GetAllAsync();

        var boughtSubjectsDto = _mapper.Map<IEnumerable<BoughtSubjectDto>>(boughtSubjects);

        return Ok(boughtSubjectsDto);
    }

    // GET: api/BoughtSubject/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var boughtSubject = await _boughtSubjectService.GetByIdAsync(id);

        if (boughtSubject == null)
        {
            return NotFound();
        }

        var boughtSubjectDto = _mapper.Map<BoughtSubjectDto>(boughtSubject);

        return Ok(boughtSubjectDto);
    }

    // GET: api/BoughtSubject/user/{userId}
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(int userId)
    {
        var boughtSubjects = await _boughtSubjectService.GetByUserIdAsync(userId);

        var boughtSubjectsDto = _mapper.Map<IEnumerable<BoughtSubjectDto>>(boughtSubjects);

        return Ok(boughtSubjectsDto);
    }

    // POST: api/BoughtSubject
    [HttpPost]
    public async Task<ActionResult<BoughtSubject>> Create(CreateBoughtSubjectDto dto)
    {
        var alreadyExists = await _boughtSubjectService.HasUserBoughtSubjectAsync(dto.UserId, dto.SubjectId);
        if (alreadyExists)
        {
            return BadRequest(new { message = "User has already purchased this subject." });
        }

        var boughtSubject = _mapper.Map<BoughtSubject>(dto);
        boughtSubject.PurchaseDate = DateOnly.FromDateTime(DateTime.UtcNow);
        var result = await _boughtSubjectService.AddAsync(boughtSubject);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, _mapper.Map<BoughtSubjectDto>(result));
    }

    // DELETE: api/BoughtSubject/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _boughtSubjectService.DeleteAsync(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    // PATCH: api/BoughtSubject/{id}/feedback
    [HttpPatch("{id}/feedback")]
    public async Task<IActionResult> UpdateFeedback(int id, [FromBody] string feedback)
    {
        var result = await _boughtSubjectService.UpdateFeedbackAsync(id, feedback);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    // GET: api/BoughtSubject/has-bought?userId={userId}&subjectId={subjectId}
    [HttpGet("has-bought")]
    public async Task<ActionResult<bool>> HasUserBoughtSubject(int userId, int subjectId)
    {
        var result = await _boughtSubjectService.HasUserBoughtSubjectAsync(userId, subjectId);
        return Ok(result);
    }
}
