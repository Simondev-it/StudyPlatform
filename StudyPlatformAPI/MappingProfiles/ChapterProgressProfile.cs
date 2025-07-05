using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.ChapterProgressDto;

namespace StudyPlatformAPI.MappingProfiles;

public class ChapterProgressProfile : Profile
{
    public ChapterProgressProfile()
    {
        CreateMap<ChapterProgress, ChapterProgressResponseDto>();
        CreateMap<CreateChapterProgressDto, ChapterProgress>();
    }
}
