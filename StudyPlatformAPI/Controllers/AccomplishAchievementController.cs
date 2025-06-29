using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.AccomplishmentAchievementDto;

namespace StudyPlatformAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccomplishAchievementController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAccomplishAchievementService _accomplishAchievementService;

    public AccomplishAchievementController(IMapper mapper, IAccomplishAchievementService accomplishAchievementService)
    {
        _mapper = mapper;
        _accomplishAchievementService = accomplishAchievementService;
    }

    // GET: api/AccomplishAchievement/user/{userId}
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(int userId)
    {
        var accomplishments = await _accomplishAchievementService.GetByUserIdAsync(userId);
        var accomplishmentsDto = _mapper.Map<IEnumerable<AccomplishAchievementResponseDto>>(accomplishments);
        return Ok(accomplishmentsDto);
    }

    // POST: api/AccomplishAchievement
    [HttpPost]
    public async Task<IActionResult> Create(CreateAccomplishAchievementDto dto)
    {
        var alreadyExists = await _accomplishAchievementService.HasUserAccomplishedAsync(dto.UserId, dto.AchievementId);

        if (alreadyExists)
        {
            return Conflict(new { message = "User has already accomplished this achievement." });
        }

        var accomplishment = _mapper.Map<AccomplishAchievement>(dto);
        var createdAccomplishment = await _accomplishAchievementService.AddAsync(accomplishment);
        var result = _mapper.Map<AccomplishAchievementResponseDto>(createdAccomplishment);
        return Ok(result);
    }

    // DELETE: api/AccomplishAchievement/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _accomplishAchievementService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound(new { message = "Accomplishment not found." });
        }
        return NoContent();
    }

    // PATCH: api/AccomplishAchievement/{id}
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PatchAccomplishAchievementDto dto)
    {
        var existingAccomplishment = await _accomplishAchievementService.GetByIdAsync(id);

        if (existingAccomplishment == null)
        {
            return NotFound();
        }

        _mapper.Map(dto, existingAccomplishment);

        var result = await _accomplishAchievementService.UpdateAsync(existingAccomplishment);

        if (!result) return StatusCode(500, "Update failed.");
        return NoContent();
    }
}
