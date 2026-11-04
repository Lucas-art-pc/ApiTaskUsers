using ApiTaskUsers.Data;
using ApiTaskUsers.Data.Dtos.Questions;
using ApiTaskUsers.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ApiTaskUsers.Services;

public class QuestionService(AppDbContext context, IMapper mapper)
{
    private readonly IMapper _mapper = mapper;
    private readonly AppDbContext  _context = context;

    public async Task<ReadQuestionDto> CreateQuestion(CreateQuestionDto createQuestionDto)
    {
        var question = _mapper.Map<Question>(createQuestionDto);
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();
        return _mapper.Map<ReadQuestionDto>(question);
    }

    public async Task<ReadQuestionDto?> GetQuestion(int id)
    {
        var question = await _context.Questions.Include(q => q.User).FirstOrDefaultAsync(question => question.Id == id);
        return question == null ? null : _mapper.Map<ReadQuestionDto>(question);
    }

    public async Task<ReadQuestionDto?> UpdateQuestion(int id, UpdateQuestionDto updateQuestionDto)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question == null)
        {
            return null;
        }
        _mapper.Map(updateQuestionDto, question);

        await _context.SaveChangesAsync();
        return _mapper.Map<ReadQuestionDto>(question);
    }

    public async Task<bool> DeleteQuestion(int id)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question == null)
        {
            return false;
        }
        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ReadQuestionDto>> GetAllQuestions()
    {
        var questions = await _context.Questions.Include(q => q.User).ToListAsync();
        return questions.Select(question => _mapper.Map<ReadQuestionDto>(question));
    }

}
