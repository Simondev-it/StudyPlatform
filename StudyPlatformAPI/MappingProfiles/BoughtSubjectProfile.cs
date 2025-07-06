using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.BoughtSubjectDto;

namespace StudyPlatformAPI.MappingProfiles;

public class BoughtSubjectProfile : Profile
{
    public BoughtSubjectProfile()
    {
        CreateMap<BoughtSubject, BoughtSubjectResponseDto>();
        //.ForMember(dest => dest.Progress, opt => opt.MapFrom(src => src.Progress));

        CreateMap<CreateBoughtSubjectDto, BoughtSubject>();
        CreateMap<UpdateBoughtSubjectDto, BoughtSubject>();
    }
}
