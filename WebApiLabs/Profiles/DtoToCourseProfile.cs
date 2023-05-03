using AutoMapper;
using WebApiLabs.DTO;
using WebApiLabs.Models;

namespace WebApiLabs.Profiles
{
    public class DtoToCourseProfile : Profile
    {
        public DtoToCourseProfile() {
            CreateMap<CourseDTO, Course>();
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                 //.ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseName))
                 //.ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
                 //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Duration))
                 
            

        }
    }
}
