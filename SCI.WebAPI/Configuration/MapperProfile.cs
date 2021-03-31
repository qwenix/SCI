using AutoMapper;
using SCI.Core.Entities;
using SCI.WebAPI.Models;
using SCI.WebAPI.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Configuration {
    public class MapperProfile : Profile {
        public MapperProfile() {
            CreateMap<AdminRegistrationRequest, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
            CreateMap<CompanyRegistrationRequest, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
            CreateMap<UserRegistrationRequest, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();

            CreateMap<CompanyRegistrationRequest, Company>().ReverseMap();
        }
    }
}
