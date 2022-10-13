using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs;
using Api.Entities;
using Api.Extensions;
using AutoMapper;

namespace Api.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser,MemberDto>()
            .ForMember(des =>des.PhotoUrl,opt => opt.MapFrom(src 
            =>src.Photos.FirstOrDefault(x =>x.IsMain).Url))
            .ForMember(des =>des.Age,opt =>opt.MapFrom(src =>src.DateOfBirth.CalculateAge()));
            
            CreateMap<Photo,PhotoDto>();
        }
    }
}