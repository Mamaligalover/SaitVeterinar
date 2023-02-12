using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using VeterinarSite.Data.Persistance;
using VeterinarSite.Data.Persistance.Entities;
using VeterinarSite.Server.Hub;
using VeterinarSite.Shared.Models;
using VeterinarSite.Shared.Services;

namespace VeterinarSite.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicalWorkerController : ControllerBase,IMedicalWorker
{

    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IHubContext<UpdateDataHub> _notificationHub;
    

    public MedicalWorkerController(AppDbContext dbContext, IMapper mapper, IHubContext<UpdateDataHub> notificationHub)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _notificationHub = notificationHub;
    }

    
    [HttpGet("get-all")]
    public async Task<IEnumerable<VeterinarWorkerModel>> GetAll()
    {
        return _mapper.Map<IEnumerable<VeterinarWorkerModel>>(await _dbContext.LucratorMedicals.ToListAsync());
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<VeterinarWorkerModel> GetById(Guid id)
    {
            return _mapper.Map<VeterinarWorkerModel>(await _dbContext.LucratorMedicals.FirstOrDefaultAsync(x => x.Id == id));
    }

    
    
    [HttpPost("add-or-update")]
    public async Task<IEnumerable<VeterinarWorkerModel>> AddorUpdate(VeterinarWorkerModel model)
    {
        var isUpdate =  model.Id !=null&& model.Id.Value != Guid.Empty;
        var request = new LucratorMedical();
        
        if (isUpdate)
        {
            request = await _dbContext.LucratorMedicals.FirstOrDefaultAsync(x => x.Id == model.Id);
            _mapper.Map(model, request);
        }
        else
        {
            _mapper.Map(model, request);
            _dbContext.LucratorMedicals.Add(request);
            await _dbContext.SaveChangesAsync();
        }

        await NotifyClientThatDataWasUpdated();
       
        return _mapper.Map<IEnumerable<VeterinarWorkerModel>>(await _dbContext.LucratorMedicals.ToListAsync());
    }

    [HttpDelete("delete/{id}")]
    public async Task<IEnumerable<VeterinarWorkerModel>> Delete(Guid id)
    {
        var request = await _dbContext.LucratorMedicals.FirstOrDefaultAsync(x => x.Id == id);
        _dbContext.LucratorMedicals.Remove(request);
        await _dbContext.SaveChangesAsync();
        await NotifyClientThatDataWasUpdated();
        return _mapper.Map<IEnumerable<VeterinarWorkerModel>>(await _dbContext.LucratorMedicals.ToListAsync());
    }

    private async Task NotifyClientThatDataWasUpdated()
    {
        await _notificationHub.Clients.All.SendAsync("NotifyMedicalWorkersHasChanged");
    }
}
