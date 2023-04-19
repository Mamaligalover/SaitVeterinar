using AutoMapper;
using VeterinarSite.Persistance;
using VeterinarSite.Persistance.Entities;
using VeterinarSite.Shared.Models;

namespace VeterinarSite.Server.Mapping;

public class MedicalCorkerMappingProfile : Profile
{
    public MedicalCorkerMappingProfile()
    {
        CreateMap<LucratorMedical, VeterinarWorkerModel>().ReverseMap();
    }
}