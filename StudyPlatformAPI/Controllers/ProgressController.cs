using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.ProgressDto;

namespace StudyPlatformAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgressController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IProgressService _progressService;

    public ProgressController(IMapper mapper, IProgressService progressService)
    {
        _mapper = mapper;
        _progressService = progressService;
    }

    // POST: api/Progress
    [HttpPost]
    public async Task<IActionResult> AddProgress(CreateProgressDto dto)
    {
        var progress = _mapper.Map<Progress>(dto);
        var createdProgress = await _progressService.AddAsync(progress);
        if (createdProgress == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating progress.");
        }
        var createdProgressDto = _mapper.Map<ProgressResponseDto>(createdProgress);
        return CreatedAtAction(nameof(GetByBoughtSubjectId), new { boughtSubjectId = createdProgress.BoughtSubjectId }, createdProgressDto);
    }

    // GET: api/Progress/boughtSubject/{boughtSubjectId}
    [HttpGet("boughtSubject/{boughtSubjectId}")]
    public async Task<IActionResult> GetByBoughtSubjectId(int boughtSubjectId)
    {
        var progress = await _progressService.GetByBoughtSubjectIdAsync(boughtSubjectId);
        if (progress == null)
        {
            return NotFound();
        }
        var progressDto = _mapper.Map<ProgressResponseDto>(progress);
        return Ok(progressDto);
    }

    // PUT: api/Progress
    [HttpPut]
    public async Task<IActionResult> UpdateProgress(UpdateProgressDto dto)
    {
        var progress = _mapper.Map<Progress>(dto);
        var updated = await _progressService.UpdateAsync(progress);
        if (!updated)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error updating progress.");
        }
        return NoContent();
    }

    // DELETE: api/Progress/{progressId}
    [HttpDelete("{progressId}")]
    public async Task<IActionResult> DeleteProgress(int progressId)
    {
        var deleted = await _progressService.DeleteAsync(progressId);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
