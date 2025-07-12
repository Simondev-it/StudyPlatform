using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.QuestionDto;

namespace StudyPlatformAPI.MappingProfiles;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<Question, QuestionResponseDto>();
        CreateMap<CreateQuestionDto, Question>();
        CreateMap<PatchQuestionDto, Question>();
    }
}
