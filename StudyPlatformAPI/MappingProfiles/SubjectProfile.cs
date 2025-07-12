using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.SubjectDto;

namespace StudyPlatformAPI.MappingProfiles;

public class SubjectProfile : Profile
{
    public SubjectProfile()
    {
        CreateMap<Subject, SubjectResponseDto>();
        CreateMap<CreateSubjectDto, Subject>();
        CreateMap<PatchSubjectDto, Subject>();
    }
}
