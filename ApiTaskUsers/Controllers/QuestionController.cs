using ApiTaskUsers.Data.Dtos.Questions;
using ApiTaskUsers.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTaskUsers.Controllers;

[ApiController]
[Route("api/v1/[controller]")]

public class QuestionController(QuestionService questionServices) : ControllerBase
{

    private readonly QuestionService _questionServices = questionServices;
    [HttpPost]
    public async Task<ActionResult> CreateQuestion([FromBody] CreateQuestionDto createQuestionDto)
    {
        var question = await _questionServices.CreateQuestion(createQuestionDto);
        return CreatedAtAction(nameof(GetQuestion), new { id = question.Id }, question);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadQuestionDto>>> GetAllQuestions()
    {
        var questions = await _questionServices.GetAllQuestions();
        return Ok(questions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadQuestionDto>> GetQuestion(int id)
    {
        var question = await _questionServices.GetQuestion(id);
        if (question == null)
        {
            return NotFound();
        }
        return Ok(question);
    }

    [HttpPut("{id}")]

    public async Task<ActionResult<ReadQuestionDto>> UpdateQuestion(int id, [FromBody] UpdateQuestionDto updateQuestionDto)
    {
        var question = await _questionServices.UpdateQuestion(id, updateQuestionDto);
        if (question == null)
        {
            return NotFound();
        }
        return Ok(question);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteQuestion(int id)
    {
        var result = await _questionServices.DeleteQuestion(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
