using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Intro
{
    public class IntroProfile : Profile
    {
        public IntroProfile()
        {
            CreateMap<Source, Destination>()
                .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.Date.Day))
                .ForMember(dest => dest.Month, opt => opt.MapFrom(src => src.Date.Month))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Date.Year));
        }
    }
}
