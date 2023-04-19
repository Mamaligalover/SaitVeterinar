namespace VeterinarSite.Persistance.Entities;

public  class ContentBase
{
    public  Guid Id { get; set; }
    public  string? ContentHeader { get; set; }
    public  string? ContentBody { get; set; }
    public  string? FooterContent { get; set; }
}