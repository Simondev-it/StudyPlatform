using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.Progress;

namespace StudyPlatformAPI.MappingProfiles;

public class ProgressProfile : Profile
{
    public ProgressProfile()
    {
        CreateMap<Progress, ProgressResponseDto>();
        CreateMap<CreateProgressDto, Progress>();
        CreateMap<UpdateProgressDto, Progress>();
    }
}
