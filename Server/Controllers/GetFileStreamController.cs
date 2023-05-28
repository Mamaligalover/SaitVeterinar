using Microsoft.AspNetCore.Mvc;
using VeterinarSite.Shared.Models;

namespace VeterinarSite.Server.Controllers;
[Route("api/get-file")]
[ApiController]
public class GetFileStreamController :ControllerBase
{
    [HttpPost("get-stream")]
    public async Task<Stream?> GetFileStream( GetFileModel model)
    {
        if (model.FilePath != null)
        {
            var  test = new GetFileModelResponse() { FileStream = System.IO.File.OpenRead(model.FilePath) };
            return System.IO.File.OpenRead(model.FilePath);
        }

        return null;
    }

    [HttpPost("get-bytearray")]
    public async Task<string?> GetFileBase64String(GetFileModel model)
    {
        if (model.FilePath != null)
        {
            var bytearray = System.IO.File.ReadAllBytes(model.FilePath);
            var base64 = Convert.ToBase64String(bytearray, 0, bytearray.Length);
            var dataUrl = "data:application/pdf;base64," + base64;
            return dataUrl;
        }

        return null;
    }
}