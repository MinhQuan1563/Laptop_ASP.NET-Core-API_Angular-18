using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace WAAL.Application.Utilities
{
    public class IFormFileToStringConverter : ITypeConverter<IFormFile, string>
    {
        public string Convert(IFormFile source, string destination, ResolutionContext context)
        {
            if (source == null) return null;

            // Xử lý ảnh và trả về URL
            var filePath = Path.Combine("Uploads", source.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                source.CopyTo(stream);
            }

            return "/Uploads/" + source.FileName; // Trả về URL của ảnh
        }
    }
}
