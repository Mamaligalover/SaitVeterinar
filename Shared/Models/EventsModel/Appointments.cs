namespace VeterinarSite.Shared.Models.EventsModel;

public class AppointmentModel
{
    public Guid? Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Text { get; set; }
    public string? Description { get; set; }
}