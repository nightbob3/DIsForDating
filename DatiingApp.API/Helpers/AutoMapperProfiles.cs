using System.Linq;
using AutoMapper;
using DatiingApp.API.Dtos;
using DatiingApp.API.Models;
using DatiingApp.API.Helpers;
using DatiingApp.API.Controllers;

namespace DatiingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
            .ForMember(dest => dest.PhotoUrl, opt => 
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
            .ForMember(dest => dest.Age, opt =>
                opt.MapFrom(src => src.DateOfBirth.GetAge()));
            CreateMap<User, UserForDetailedDto>()
            .ForMember(dest => dest.PhotoUrl, opt => 
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
            .ForMember(dest => dest.Age, opt =>
                opt.MapFrom(src => src.DateOfBirth.GetAge()));
            CreateMap<Photo, PhotosForDetailedDto>();

            CreateMap<UserForUpdatesDto, User>(); 
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();
            CreateMap<UserForRegisterDto, User>();
        }
    }
}