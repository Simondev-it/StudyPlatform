using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.CommentDto;

namespace StudyPlatformAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICommentService _commentService;

    public CommentController(IMapper mapper, ICommentService commentService)
    {
        _mapper = mapper;
        _commentService = commentService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _commentService.GetAllAsync();
        var commentsDto = _mapper.Map<IEnumerable<CommentResponseDto>>(comments);
        return Ok(commentsDto);
    }

    // GET: api/Comment/question/{questionId}
    [HttpGet("question/{questionId}")]
    public async Task<IActionResult> GetByQuestionId(int questionId)
    {
        var comments = await _commentService.GetByQuestionIdAsync(questionId);
        var commentsDto = _mapper.Map<IEnumerable<CommentResponseDto>>(comments);
        return Ok(commentsDto);
    }

    // POST: api/Comment
    [HttpPost]
    public async Task<IActionResult> Create(CreateCommentDto dto)
    {
        var comment = _mapper.Map<Comment>(dto);
        var createdComment = await _commentService.CreateAsync(comment);
        var createdCommentDto = _mapper.Map<CommentResponseDto>(createdComment);
        return Ok(createdCommentDto);
    }

    // PATCH: api/Comment/{id}
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PatchCommentDto dto)
    {
        var existingComment = await _commentService.GetByIdAsync(id);
        if (existingComment == null)
        {
            return NotFound();
        }

        _mapper.Map(dto, existingComment);

        var result = await _commentService.UpdateAsync(existingComment);

        if (!result) return StatusCode(500, "Update failed.");
        return NoContent();
    }

    // DELETE: api/Comment/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _commentService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
