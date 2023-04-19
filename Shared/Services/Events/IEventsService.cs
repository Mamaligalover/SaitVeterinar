using VeterinarSite.Shared.Models.EventsModel;

namespace VeterinarSite.Shared.Services.Events;

public interface IEventsService
{
    Task<IEnumerable<AppointmentModel>> GetAllApointments();
    Task Add(AppointmentModel model);
    Task Edit(AppointmentModel model);
}