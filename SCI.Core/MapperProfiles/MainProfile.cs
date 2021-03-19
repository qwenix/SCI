using AutoMapper;
using SCI.Core.DTOs;
using SCI.Core.Entities;
using SCI.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.SharedKernel.MapperProfiles {
    public class MainProfile : Profile {
        public MainProfile() {
            CreateMap<UserDTO, UserModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name))
                .ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}
