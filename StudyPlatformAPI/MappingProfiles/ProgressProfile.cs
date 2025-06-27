using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.ProgressDto;

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
