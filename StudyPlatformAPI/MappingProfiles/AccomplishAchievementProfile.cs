using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.AccomplishmentAchievementDto;

namespace StudyPlatformAPI.MappingProfiles;

public class AccomplishAchievementProfile : Profile
{
    public AccomplishAchievementProfile()
    {
        CreateMap<AccomplishAchievement, AccomplishAchievementResponseDto>();
        CreateMap<CreateAccomplishAchievementDto, AccomplishAchievement>();
        CreateMap<PatchAccomplishAchievementDto, AccomplishAchievement>();
    }
}
