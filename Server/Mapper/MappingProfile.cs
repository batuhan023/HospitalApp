using AutoMapper;
using HospitalApp.Shared;
using HospitalApp.Shared.Model;

namespace HospitalApp.Server.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor,DoctoDTO>().ReverseMap();
        }
    }
}
