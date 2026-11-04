using System.ComponentModel.DataAnnotations;

namespace ApiTaskUsers.Data.Dtos.Questions;

public class CreateQuestionDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int UserId { get; set; }
}
