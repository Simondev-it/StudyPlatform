using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.FollowingDto;

namespace StudyPlatformAPI.MappingProfiles;

public class FollowingProfile : Profile
{
    public FollowingProfile()
    {
        CreateMap<Following, FollowingResponseDto>();
        CreateMap<CreateFollowingDto, Following>();
    }
}
