using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinarSite.Persistance;
using VeterinarSite.Persistance.Entities;
using VeterinarSite.Shared.Models.EventsModel;
using VeterinarSite.Shared.Services.Events;

namespace VeterinarSite.Server.Controllers;

[Route("api/events")]
[ApiController]
public class EventsController : ControllerBase, IEventsService
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _dbContext;

    public EventsController(IMapper mapper, AppDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    [HttpGet("getall")]
    public async Task<IEnumerable<AppointmentModel>> GetAllApointments()
    {
        return _mapper.Map<IEnumerable<AppointmentModel>>(await _dbContext.Events.ToListAsync());
    }

    [HttpPost("add")]
    public async Task Add(AppointmentModel model)
    {
        var request = new Event();
        _mapper.Map(model, request);
        _dbContext.Events.Add(request);
        await _dbContext.SaveChangesAsync();
    }

    [HttpPatch("edit")]
    public async Task Edit(AppointmentModel model)
    {
        var request = await _dbContext.Events.FirstOrDefaultAsync(sr => sr.Id == model.Id);
        _mapper.Map(model, request);
        await _dbContext.SaveChangesAsync();
    }
}