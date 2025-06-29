using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.FollowingDto;

namespace StudyPlatformAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FollowingController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IFollowingService _followingService;

    public FollowingController(IMapper mapper, IFollowingService followingService)
    {
        _mapper = mapper;
        _followingService = followingService;
    }

    // GET: api/Following/user/{userId}
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(int userId)
    {
        var followings = await _followingService.GetByUserIdAsync(userId);
        var followingsDto = _mapper.Map<IEnumerable<FollowingResponseDto>>(followings);
        return Ok(followingsDto);
    }

    // POST: api/Following
    [HttpPost]
    public async Task<IActionResult> CreateFollowing(CreateFollowingDto dto)
    {
        var alreadyExists = await _followingService.HasUserFollowedAsync(dto.UserId, dto.FollowingId);
        if (alreadyExists)
        {
            return BadRequest("User already follows this account.");
        }

        var following = _mapper.Map<Following>(dto);
        var createdFollowing = await _followingService.CreateAsync(following);
        var result = _mapper.Map<FollowingResponseDto>(createdFollowing);
        return Ok(result);
    }

    // DELETE: api/Following/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFollowing(int id)
    {
        var result = await _followingService.DeleteAsync(id);
        if (!result)
        {
            return NotFound("Following not found.");
        }
        return NoContent();
    }
}
