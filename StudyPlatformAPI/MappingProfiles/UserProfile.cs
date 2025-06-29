using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.User;

namespace StudyPlatformAPI.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserLoginDTO, User>();
            CreateMap<User, UserResponseDTO>();
            CreateMap<User, UserResponseNoPasswordDTO>();
        }
    }
    
    }

