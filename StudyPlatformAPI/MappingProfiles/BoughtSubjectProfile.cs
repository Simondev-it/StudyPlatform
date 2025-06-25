using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs;

namespace StudyPlatformAPI.MappingProfiles;

public class BoughtSubjectProfile : Profile
{
    public BoughtSubjectProfile()
    {
        CreateMap<BoughtSubject, BoughtSubjectDto>();
        CreateMap<CreateBoughtSubjectDto, BoughtSubject>();
    }
}
