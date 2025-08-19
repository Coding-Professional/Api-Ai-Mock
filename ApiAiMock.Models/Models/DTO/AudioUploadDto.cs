using Microsoft.AspNetCore.Http;

namespace ApiAiMock.Models.DTO
{
    public class AudioUploadDto
    {
        public string SessionId { get; set; }
        public IFormFile Audio { get; set; }
    }
}
