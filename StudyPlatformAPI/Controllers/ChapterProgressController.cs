using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.ChapterProgressDto;

namespace StudyPlatformAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChapterProgressController : ControllerBase
{
    private readonly IChapterProgressService _chapterProgressService;
    private readonly IMapper _mapper;

    public ChapterProgressController(IChapterProgressService chapterProgressService, IMapper mapper)
    {
        _chapterProgressService = chapterProgressService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await _chapterProgressService.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<ChapterProgressResponseDto>(result));
    }

    [HttpPost("")]
    public async Task<ActionResult> Create(CreateChapterProgressDto dto)
    {
        var chapterProgress = _mapper.Map<ChapterProgress>(dto);
        chapterProgress.StartDate = DateOnly.FromDateTime(DateTime.Now);
        var result = await _chapterProgressService.CreateAsync(chapterProgress);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, _mapper.Map<ChapterProgressResponseDto>(result));
    }
}
