using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.QuestionDto;

namespace StudyPlatformAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IQuestionService _questionService;

    public QuestionController(IMapper mapper, IQuestionService questionService)
    {
        _mapper = mapper;
        _questionService = questionService;
    }

    [HttpPost]
    public async Task<IActionResult> AddQuestion([FromBody] CreateQuestionDto dto)
    {
        var question = _mapper.Map<Question>(dto);
        var createdQuestion = await _questionService.Add(question);
        if (createdQuestion == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating question.");
        }
        var createdQuestionDto = _mapper.Map<QuestionResponseDto>(createdQuestion);
        return Ok(createdQuestionDto);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateQuestion(int id, [FromBody] PatchQuestionDto dto)
    {
        var existingQuestion = await _questionService.GetByIdAsync(id);
        if (existingQuestion == null)
        {
            return NotFound();
        }
        _mapper.Map(dto, existingQuestion);
        var result = await _questionService.Update(existingQuestion);
        if (!result) return StatusCode(500, "Update failed.");
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuestion(int id)
    {
        var result = await _questionService.Delete(id);
        if (!result) return NotFound();
        return NoContent();
    }

}
    