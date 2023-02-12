using Microsoft.AspNetCore.Mvc;
using VeterinarSite.Data.Persistance;

namespace VeterinarSite.Server.Controllers;
[Route("upload")]
[ApiController]
public partial class UploadFileController : Controller
{
    private readonly AppDbContext _dbContext;

    public UploadFileController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
}