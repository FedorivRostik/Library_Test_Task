using Microsoft.AspNetCore.Http;

namespace Core.Interfaces.Services;
public interface IPictureService
{
    public string GetBase64FromFile(IFormFile formFile);
}
