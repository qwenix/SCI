using AutoMapper;
using SCI.Core.Entities;
using SCI.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Configuration {
    public class MapperProfile : Profile {
        public MapperProfile() {
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name))
                .ReverseMap();
        }
    }
}
