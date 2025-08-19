using Microsoft.AspNetCore.Http;
namespace ApiAiMock.Models.DTO
{
    public class FrameUploadDto
    {
        public string SessionId { get; set; }
        public IFormFile Frame { get; set; }
    }
}
