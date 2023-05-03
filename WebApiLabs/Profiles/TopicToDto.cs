using AutoMapper;
using WebApiLabs.DTO;
using WebApiLabs.Models;

namespace WebApiLabs.Profiles
{
    public class TopicToDto: Profile
    {
        public TopicToDto() {
        
            CreateMap<Topic, TopicDTO>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses.Select(c => c.CourseName)
                .ToHashSet()));
        }
    }
}
