﻿using AutoMapper;
using SCI.Core.Entities;
using SCI.Core.Models;
using SCI.WebAPI.Models;
using SCI.WebAPI.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.WebAPI.Configuration {
    public class MapperProfile : Profile {
        public MapperProfile() {
            CreateMap<AdminRegistrationRequest, ApplicationUser>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(model => model))
                .ReverseMap();
            CreateMap<AdminRegistrationRequest, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(model => model.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(model => model.Email))
                .ReverseMap();

            CreateMap<DriverRegistrationRequest, Driver>()
                .ForMember(dest => dest.ApplicationUser, opt => opt.MapFrom(model => model))
                .ReverseMap();
            CreateMap<DriverRegistrationRequest, ApplicationUser>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(model => model))
                .ReverseMap();
            CreateMap<DriverRegistrationRequest, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(model => model.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(model => model.Email))
                .ReverseMap();

            CreateMap<CompanyRegistrationRequest, Company>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(model => model))
                .ReverseMap();
            CreateMap<CompanyRegistrationRequest, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(model => model.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(model => model.Email))
                .ReverseMap();

            CreateMap<CompanyRegistrationRequest, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(model => model.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(model => model.Email))
                .ReverseMap();

            CreateMap<IEnumerable<Ride>, DriverReview>()
                .ForMember(dest => dest.AverageRideMiles, 
                    opt => opt.MapFrom(model => model.Average(r => r.Mileage)))
                .ForMember(dest => dest.AverageSpeed, 
                    opt => opt.MapFrom(model => model.Average(r => r.AverageSpeed)))
                .ForMember(dest => dest.Mileage, 
                    opt => opt.MapFrom(model => model.Sum(r => r.Mileage)))
                .ForMember(dest => dest.OverspeedingAmount, 
                    opt => opt.MapFrom(model => model.Sum(r => r.OverSpeedingAmount)))
                .ForMember(dest => dest.PhoneUsageTime, 
                    opt => opt.MapFrom(model => model.Sum(r => r.PhoneUsageTime)))
                .ForMember(dest => dest.SharpSlowDownsAmount, 
                    opt => opt.MapFrom(model => model.Sum(r => r.SharpSlowDownsAmount)))
                .ForMember(dest => dest.SharpSpeedUpsAmount, opt => 
                    opt.MapFrom(model => model.Sum(r => r.SharpSpeedUpsAmount)))
                .ForMember(dest => dest.SharpSteeringsWheelAmount, 
                    opt => opt.MapFrom(model => model.Sum(r => r.SharpSteeringsWheelAmount)))
                .ForMember(dest => dest.SharpTurnEntriesAmount, 
                    opt => opt.MapFrom(model => model.Sum(r => r.SharpTurnEntriesAmount)));
        }
    }
}
