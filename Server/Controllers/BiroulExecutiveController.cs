using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using VeterinarSite.Persistance;
using VeterinarSite.Persistance.Entities;
using VeterinarSite.Server.Hub;
using VeterinarSite.Shared.Models.BiroulExecutiv;
using VeterinarSite.Shared.Services;

namespace VeterinarSite.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BiroulExecutiveController : Controller, IBiroulExecutivService
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IHubContext<ComisionHub> _notificationHub;


    public BiroulExecutiveController(AppDbContext dbContext, IMapper mapper,
        IHubContext<ComisionHub> notificationHub)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _notificationHub = notificationHub;
    }

    [HttpDelete("delete/{Id}")]
    public async Task Delete(Guid? Id)
    {
        var request = await _dbContext.BirouExecutivCMVs
            .FirstOrDefaultAsync(sr => sr.Id == Id.Value);
        if (request != null)
        {
            _dbContext.BirouExecutivCMVs.Remove(request);
            await _dbContext.SaveChangesAsync();
            SendNotification();
        }
    }


    [HttpGet("getall")]
    public async Task<IEnumerable<ComisionModel>> GetAll()
    {
        return _mapper.Map<IEnumerable<ComisionModel>>(await _dbContext.BirouExecutivCMVs.Include(x => x.FileNam)
            .ThenInclude(s => s.FileContent).ToListAsync());
    }

    [HttpPost("upload/{Id}")]
    public async Task<IActionResult> AddOrUpdateFileAsync(IFormFile file,[FromRoute] string Id)
    {
        
            var request = await _dbContext.BirouExecutivCMVs
                .Include(sr=>sr.FileNam)
                .ThenInclude(sr=>sr.FileContent)
                .FirstOrDefaultAsync(x => x.Id == Guid.Parse(Id));
        if (request != null)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                if (request.FileNameId == null)
                {
                    var fileID = Guid.NewGuid();
                    request.FileNameId = fileID;
                    request.FileNam = new FileName()
                    {
                        Id = fileID,
                        Name = file.FileName,
                        FileType = file.ContentType,
                        FileContent = new FileContent()
                        {
                            Id = Guid.NewGuid(),
                            Content = ms.ToArray()
                        }
                    };
                }
                else
                {
                    request.FileNam.FileContent.Content = ms.ToArray();
                    request.FileNam.Name = file.FileName;
                    request.FileNam.FileType = file.ContentType;
                }
            }

            await _dbContext.SaveChangesAsync();
            SendNotification();
            return StatusCode(200);
        }
        return StatusCode(400);
    }


    [HttpGet("getbyid/{Id}")]
    public async Task<ComisionModel> GetById(Guid? Id)
    {
        return _mapper.Map<ComisionModel>(
            await _dbContext.BirouExecutivCMVs.FirstOrDefaultAsync(sr => sr.Id == Id.Value));
    }


    [HttpPost("addorupdate")]
    public async Task AddorUpdate(ComisionModel model)
    {
        if (model.Id == Guid.Empty || model.Id == null)
            // if id is null then its a new record
        {
            model.Id = Guid.NewGuid();
            _dbContext.BirouExecutivCMVs.Add(_mapper.Map<BirouExecutivCMV>(model));
        }
        else
        {
            var request = await _dbContext.BirouExecutivCMVs
                .FirstOrDefaultAsync(sr => sr.Id == model.Id);
            if (request != null)
            {
                _mapper.Map(model, request);
            }
        }
        await _dbContext.SaveChangesAsync();
        SendNotification();
    }
[HttpGet("test")]
    public Task<bool> UploadImage()
    {
        throw new NotImplementedException();
    }

    // public async Task<bool> UploadImage()
    // {
    //     throw new NotImplementedException();
    // }

    private void SendNotification()
    {
        _notificationHub.Clients.All.SendAsync("UpdateData");
    }
}