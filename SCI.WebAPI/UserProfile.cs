using AutoMapper;
using SCI.Infrastructure.Entities;
using SCI.WebAPI.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.WebAPI {
    public class UserProfile : Profile {
        public UserProfile() {
            CreateMap<UserModel, User>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<User, AuthenticationResponse>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
