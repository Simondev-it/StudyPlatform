using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.BoughtSubject;

namespace StudyPlatformAPI.MappingProfiles;

public class BoughtSubjectProfile : Profile
{
    public BoughtSubjectProfile()
    {
        CreateMap<BoughtSubject, BoughtSubjectResponseDto>();
        CreateMap<CreateBoughtSubjectDto, BoughtSubject>();
    }
}
