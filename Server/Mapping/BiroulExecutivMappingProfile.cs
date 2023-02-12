using AutoMapper;
using VeterinarSite.Data.Persistance.Entities;
using VeterinarSite.Shared.Models.BiroulExecutiv;

namespace VeterinarSite.Server.Mapping;

public class BiroulExecutivMappingProfil : Profile
{
    public BiroulExecutivMappingProfil()
    {
        CreateMap<BirouExecutivCMV, ComisionModel>()
            .ForMember(dest=>dest.FileContetnt,opt=>opt.MapFrom(src=>src.FileNam.FileContent.Content))
            .ReverseMap();
        CreateMap<ComponentaComisieiDentologiceSiLitigii, ComisionModel>()
            .ForMember(dest=>dest.FileContetnt,opt=>opt.MapFrom(src=>src.FileNam.FileContent.Content))
            .ReverseMap();
        CreateMap<Cenzor, ComisionModel>()
            .ForMember(dest=>dest.FileContetnt,opt=>opt.MapFrom(src=>src.FileNam.FileContent.Content))
            .ReverseMap();
        CreateMap<SearchAndResourchePeople, ComisionModel>()
            .ForMember(dest=>dest.FileContetnt,opt=>opt.MapFrom(src=>src.FileNam.FileContent.Content))
            .ReverseMap();
    }
}