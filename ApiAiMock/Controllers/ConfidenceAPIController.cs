using ApiAiMock.Application.Interfaces;
using ApiAiMock.Domain.Entities;
using ApiAiMock.Models;
using ApiAiMock.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ApiAiMock.Controllers
{
    [ApiController]
    [Route("api/analysis")]
    public class ConfidenceAPIController : ControllerBase
    {
        private readonly IConfidenceService _confidenceService;

        public ConfidenceAPIController(IConfidenceService confidenceService)
        {
            _confidenceService = confidenceService;
        }

        [HttpPost("frame")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadFrame([FromForm] FrameUploadDto request)
        {
            if (string.IsNullOrEmpty(request.SessionId) || request.Frame == null || request.Frame.Length == 0)
            {
                return BadRequest("Session ID and a valid frame are required.");
            }

            await _confidenceService.ProcessFrameAsync(request.SessionId, request.Frame.OpenReadStream());
            return Ok();
        }

        [HttpPost("audio")]
        [Consumes("multipart/form-data")]
        public IActionResult UploadAudio([FromForm] AudioUploadDto request)
        {
            if (string.IsNullOrEmpty(request.SessionId) || request.Audio == null || request.Audio.Length == 0)
            {
                return BadRequest("Session ID and a valid audio file are required.");
            }

            _ = _confidenceService.ProcessAudioAsync(request.SessionId, request.Audio.OpenReadStream());
            return Accepted();
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetReport([FromQuery] string sessionId)
        {
            if (string.IsNullOrEmpty(sessionId))
            {
                return BadRequest("Session ID is required.");
            }

            var result = await _confidenceService.GetConfidenceReportAsync(sessionId);

            if (result == null)
            {
                return Accepted();
            }

            var reportDto = new ConfidenceReportDto
            {
                SessionId = result.SessionId,
                Score = result.Score,
                Visual = new VisualReportDto
                {
                    EyeContactRatio = result.Visual.EyeContactRatio,  
                    Frames = result.Visual.Frames
                },
                Speech = new SpeechReportDto
                {
                    Wpm = result.Speech.Wpm,
                    FillerCount = result.Speech.FillerCount,
                    AvgPauseMs = result.Speech.AvgPauseMs
                },
                Sentiment = new SentimentReportDto
                {
                    Positive = result.Sentiment.Positive,
                    Neutral = result.Sentiment.Neutral,
                    Negative = result.Sentiment.Negative
                }
            };

            return Ok(reportDto);
        }

    }
}
