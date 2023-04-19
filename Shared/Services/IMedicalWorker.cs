using VeterinarSite.Shared.Models;

namespace VeterinarSite.Shared.Services;

public interface IMedicalWorker
{
    Task<IEnumerable<VeterinarWorkerModel>> GetAll();
    Task<IEnumerable<VeterinarWorkerModel>> AddorUpdate(VeterinarWorkerModel model);
    Task<IEnumerable<VeterinarWorkerModel>> Delete(Guid id);
    Task<VeterinarWorkerModel> GetById(Guid id);

}