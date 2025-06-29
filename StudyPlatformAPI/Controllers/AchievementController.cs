using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using StudyPlatformAPI.DTOs.AchievementDto;

namespace StudyPlatformAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AchievementController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAchievementService _achievementService;

    public AchievementController(IMapper mapper, IAchievementService achievementService)
    {
        _mapper = mapper;
        _achievementService = achievementService;
    }

    // GET: api/Achievement
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var achievements = await _achievementService.GetAllAsync();
        var achievementsDto = _mapper.Map<IEnumerable<AchievementResponseDto>>(achievements);
        return Ok(achievementsDto);
    }

    // GET: api/Achievement/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var achievement = await _achievementService.GetByIdAsync(id);
        if (achievement == null)
        {
            return NotFound();
        }
        var achievementDto = _mapper.Map<AchievementResponseDto>(achievement);
        return Ok(achievementDto);
    }
}
