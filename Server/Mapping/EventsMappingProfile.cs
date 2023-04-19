using AutoMapper;
using VeterinarSite.Shared.Models.EventsModel;
using VeterinarSite.Persistance.Entities;

namespace VeterinarSite.Server.Mapping;

public class EventsMappingProfile : Profile
{
    public EventsMappingProfile()
    {
        CreateMap<Event, AppointmentModel>();
        CreateMap<AppointmentModel,Event>()
            .ForMember(dest=>dest.Id,opt=>opt.Ignore());
    }
}