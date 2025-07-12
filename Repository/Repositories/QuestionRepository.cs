using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using StudyPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly StudyPlatformContext _context;

    public QuestionRepository(StudyPlatformContext context)
    {
        _context = context;
    }

    public async Task<Question> Add(Question question)
    {
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();
        return question;
    }

    public async Task<bool> Delete(int questionId)
    {
        var question = await _context.Questions.FindAsync(questionId);
        if (question == null) return false;
        _context.Questions.Remove(question);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(Question question)
    {
        //var existingQuestion = await _context.Questions.FindAsync(question.Id);
        //if (existingQuestion == null) return false;
        //existingQuestion.Number = question.Number;
        //existingQuestion.Type = question.Type;
        //existingQuestion.Question1 = question.Question1;
        //existingQuestion.CorrectAnswer = question.CorrectAnswer;
        //existingQuestion.Answers = question.Answers;
        //existingQuestion.Explanation = question.Explanation;
        //existingQuestion.Note = question.Note;
        //return await _context.SaveChangesAsync() > 0;

        _context.Entry(question).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Question?> GetByIdAsync(int id)
    {
        return await _context.Questions.FindAsync(id);
    }
}
