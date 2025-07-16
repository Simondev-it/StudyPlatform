using AutoMapper;
using StudyPlatform.Models;
using StudyPlatformAPI.DTOs.User;

namespace StudyPlatformAPI.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // In your AutoMapper profile:
            CreateMap<UserUpdateDTO, User>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserLoginDTO, User>();
            CreateMap<UserLoginByUsernameDTO, User>();
            CreateMap<User, UserResponseDTO>();
            CreateMap<User, UserResponseNoPasswordDTO>();
        }
    }
    
    }

