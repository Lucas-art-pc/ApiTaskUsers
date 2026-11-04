using ApiTaskUsers.Data.Dtos.Questions;

using ApiTaskUsers.Models;
using AutoMapper;

namespace ApiTaskUsers.Profiles;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<CreateQuestionDto, Question>();
        CreateMap<Question, ReadQuestionDto>();
        CreateMap<ReadQuestionDto, Question>();
        CreateMap<UpdateQuestionDto, Question>();
    }
}
