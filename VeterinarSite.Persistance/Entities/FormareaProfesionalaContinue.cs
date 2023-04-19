namespace VeterinarSite.Persistance.Entities;

public class FormareaProfesionalaContinue
{
    public Guid Id { get; set; }
    public Guid? FileNameId { get; set; }
    public FileName? FileName { get; set; }
}