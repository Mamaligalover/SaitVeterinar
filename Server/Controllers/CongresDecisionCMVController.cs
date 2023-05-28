using MediatR;
using Microsoft.AspNetCore.Mvc;
using VeterinarSite.Persistance;

namespace VeterinarSite.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CongresDecisionCMVController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public CongresDecisionCMVController(IMediator mediator)
    {
        _mediator = mediator;
    }

    
}