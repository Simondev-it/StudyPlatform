using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using Service.Interfaces;
using StudyPlatform.Models;

namespace Service.Service;

public class CommentService : ICommentService
{
    private readonly IUnitOfWork _unitOfWork;

    public CommentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Comment> CreateAsync(Comment comment)
    {
        comment.CommentDate = DateTime.Now;
        return await _unitOfWork.CommentRepository.CreateAsync(comment);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var comment = await _unitOfWork.CommentRepository.GetByIdAsync(id);

        if (comment == null)
        {
            return false;
        }

        return await _unitOfWork.CommentRepository.DeleteAsync(comment);
    }

    public async Task<IEnumerable<Comment>> GetAllAsync()
    {
        return await _unitOfWork.CommentRepository.GetAllAsync();
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _unitOfWork.CommentRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Comment>> GetByQuestionIdAsync(int questionId)
    {
        return await _unitOfWork.CommentRepository.GetByQuestionIdAsync(questionId);
    }

    public async Task<bool> UpdateAsync(Comment comment)
    {
        comment.Content = comment.Content;
        comment.CommentDate = DateTime.Now;
        return await _unitOfWork.CommentRepository.UpdateAsync(comment);
    }
}
