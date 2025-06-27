using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.TopicProgress;

namespace StudyPlatformAPI.MappingProfiles
{
    public class TopicProgressProfile : Profile
    {
        public TopicProgressProfile()
        {
            // CreateMap<TopicProgress, TopicProgressResponseDto>();
            CreateMap<TopicProgressCreateDTO, TopicProgress>();
            CreateMap<TopicProgress, TopicProgressResponseDTO>();
        }
    }
    
    
}
