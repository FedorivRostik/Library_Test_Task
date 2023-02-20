using Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace Application.Services;
public class PictureService : IPictureService
{
    public string GetBase64FromFile(IFormFile formFile)
    {
        string imageAsBase64 = default(string)!;
        if (formFile is not null)
        {
            using var ms = new MemoryStream();

            formFile.CopyTo(ms);
            byte[] formFileAsBytes = ms.ToArray()!;
            imageAsBase64 = Convert.ToBase64String(formFileAsBytes)!;
            return imageAsBase64;
        }
        return imageAsBase64;
    }
}
