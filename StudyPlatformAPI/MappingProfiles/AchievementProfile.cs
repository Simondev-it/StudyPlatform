using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.AchievementDto;

namespace StudyPlatformAPI.MappingProfiles;

public class AchievementProfile : Profile
{
    public AchievementProfile()
    {
        CreateMap<Achievement, AchievementResponseDto>();
    }
}
