using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<About,ResultAboutDto>().ReverseMap();
            CreateMap<About,GetAboutDto>().ReverseMap();
            CreateMap<About,CreateAboutDto>().ReverseMap();
            CreateMap<About,UpdateAboutDto>().ReverseMap();

        }
    }

}
