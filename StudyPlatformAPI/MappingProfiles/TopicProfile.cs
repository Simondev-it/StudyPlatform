using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.TopicDto;

namespace StudyPlatformAPI.MappingProfiles;

public class TopicProfile : Profile
{
    public TopicProfile()
    {
        CreateMap<Topic, TopicResponseDto>();
    }
}
