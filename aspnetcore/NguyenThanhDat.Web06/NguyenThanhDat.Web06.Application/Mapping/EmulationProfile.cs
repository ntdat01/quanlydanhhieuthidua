using AutoMapper;
using NguyenThanhDat.Web06.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Application
{
    public class EmulationProfile : Profile
    {
        public EmulationProfile()
        {
            CreateMap<Emulation, EmulationDto>();
            CreateMap<EmulationCreateDto, Emulation>();
            CreateMap<EmulationUpdateDto, Emulation>();
        }
    }
}
