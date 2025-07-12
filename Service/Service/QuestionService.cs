using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using Service.Interfaces;
using StudyPlatform.Models;

namespace Service.Service;

public class QuestionService : IQuestionService
{
    private readonly IUnitOfWork _unitOfWork;

    public QuestionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Question> Add(Question question)
    {
        return await _unitOfWork.QuestionRepository.Add(question);
    }

    public async Task<bool> Delete(int questionId)
    {
        return await _unitOfWork.QuestionRepository.Delete(questionId);
    }

    public async Task<bool> Update(Question question)
    {
        return await _unitOfWork.QuestionRepository.Update(question);
    }

    public async Task<Question?> GetByIdAsync(int id)
    {
        return await _unitOfWork.QuestionRepository.GetByIdAsync(id);
    }
}
