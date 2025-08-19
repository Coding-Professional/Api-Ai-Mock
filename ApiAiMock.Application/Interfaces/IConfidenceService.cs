using ApiAiMock.Domain.Entities;
using ApiAiMock.Models;
using System.IO;
using System.Threading.Tasks;

namespace ApiAiMock.Application.Interfaces
{
    public interface IConfidenceService
    {
        Task ProcessFrameAsync(string sessionId, Stream frameStream);
        Task ProcessAudioAsync(string sessionId, Stream audioStream);
        Task<ConfidenceReportDto> GetConfidenceReportAsync(string sessionId);
    }
}