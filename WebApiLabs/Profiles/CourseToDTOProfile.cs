using AutoMapper;
using WebApiLabs.DTO;
using WebApiLabs.Models;

namespace WebApiLabs.Profiles
{
    public class CourseToDTOProfile: Profile
    {
        public CourseToDTOProfile() {
            CreateMap<Course, CourseDTO>()
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                 //.ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseName))
                 //.ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
                 //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Duration))
                 .ForMember(dest => dest.TopicName, opt => opt.MapFrom(src => src.Topic.Title));
            

        }
    }
}
