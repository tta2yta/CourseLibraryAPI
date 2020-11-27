using AutoMapper;
using CourseLibraryAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibraryAPI.Profiles
{
    public class AuthorProfile: Profile
    {
        public AuthorProfile()
        {
            CreateMap<Entities.Author, Model.AuthorDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age,
                opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge())
                );

            CreateMap<Model.AuthorCreationDto, Entities.Author>();
        }
    }
}
