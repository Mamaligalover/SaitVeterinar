using VeterinarSite.Shared.Models.BiroulExecutiv;

namespace VeterinarSite.Shared.Services;

public interface ICenzors
{
    Task Delete(Guid? Id);
    
    Task<IEnumerable<ComisionModel>> GetAll();
    Task<ComisionModel> GetById(Guid? Id);
    Task AddorUpdate(ComisionModel model);
    Task<bool> UploadImage();
}