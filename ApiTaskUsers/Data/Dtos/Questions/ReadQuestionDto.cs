

using ApiTaskUsers.Data.Dtos.Users;

namespace ApiTaskUsers.Data.Dtos.Questions;

public class ReadQuestionDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ReadUserDto User { get; set; }


}
