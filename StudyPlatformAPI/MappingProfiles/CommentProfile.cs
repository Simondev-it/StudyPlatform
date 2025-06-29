using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.CommentDto;

namespace StudyPlatformAPI.MappingProfiles;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, CommentResponseDto>();
        CreateMap<CreateCommentDto, Comment>();
        CreateMap<PatchCommentDto, Comment>();
    }
}
