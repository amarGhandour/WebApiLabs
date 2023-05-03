using AutoMapper;
using WebApiLabs.DTO;
using WebApiLabs.Models;

namespace WebApiLabs.Profiles
{
    public class DtoToTopic : Profile
    {
        public DtoToTopic() {

            CreateMap<TopicDTO, Topic>();
        }
    }
}
