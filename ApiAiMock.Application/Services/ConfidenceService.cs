using ApiAiMock.Application.Interfaces;
using ApiAiMock.Domain.Entities;
using ApiAiMock.Models;
using System.Collections.Concurrent;

namespace ApiAiMock.Application.Services
{
    public class ConfidenceService : IConfidenceService
    {
        // In-memory storage for demo purposes
        private readonly ConcurrentDictionary<string, ConfidenceResult> _sessions = new();

        public async Task ProcessFrameAsync(string sessionId, Stream frameStream)
        {
            // Mock processing - simulate some async work
            await Task.Delay(100);
            
            var result = _sessions.GetOrAdd(sessionId, _ => new ConfidenceResult
            {
                SessionId = sessionId,
                OverallScore = 0.75,
                EyeContactRatio = 0.8,
                AnalyzedFrames = 0,
                WordsPerMinute = 0,
                FillerWordCount = 0,
                AveragePauseDurationMs = 0,
                PositiveSentiment = 0.6,
                NeutralSentiment = 0.3,
                NegativeSentiment = 0.1
            });

            // Simulate frame analysis
            result.AnalyzedFrames++;
            result.EyeContactRatio = Math.Min(1.0, result.EyeContactRatio + 0.01);
        }

        public async Task ProcessAudioAsync(string sessionId, Stream audioStream)
        {
            // Mock processing - simulate some async work
            await Task.Delay(200);
            
            var result = _sessions.GetOrAdd(sessionId, _ => new ConfidenceResult
            {
                SessionId = sessionId,
                OverallScore = 0.75,
                EyeContactRatio = 0.8,
                AnalyzedFrames = 0,
                WordsPerMinute = 120,
                FillerWordCount = 5,
                AveragePauseDurationMs = 800,
                PositiveSentiment = 0.6,
                NeutralSentiment = 0.3,
                NegativeSentiment = 0.1
            });

            // Simulate audio analysis updates
            result.WordsPerMinute = Random.Shared.Next(100, 150);
            result.FillerWordCount = Random.Shared.Next(0, 10);
            result.AveragePauseDurationMs = Random.Shared.Next(500, 1200);
        }

        public async Task<ConfidenceReportDto> GetConfidenceReportAsync(string sessionId)
        {
            await Task.Delay(50);

            if (_sessions.TryGetValue(sessionId, out var result))
            {
                result.OverallScore = (result.EyeContactRatio + result.PositiveSentiment) / 2.0;

                return new ConfidenceReportDto
                {
                    SessionId = result.SessionId,
                    Score = result.OverallScore,
                    Visual = new VisualReportDto
                    {
                        EyeContactRatio = result.EyeContactRatio,
                        Frames = result.AnalyzedFrames
                    },
                    Speech = new SpeechReportDto
                    {
                        Wpm = result.WordsPerMinute,
                        FillerCount = result.FillerWordCount,
                        AvgPauseMs = result.AveragePauseDurationMs
                    },
                    Sentiment = new SentimentReportDto
                    {
                        Positive = result.PositiveSentiment,
                        Neutral = result.NeutralSentiment,
                        Negative = result.NegativeSentiment
                    }
                };
            }

            // Return a default report instead of null to satisfy nullable reference types
            return new ConfidenceReportDto
            {
                SessionId = sessionId,
                Score = 0,
                Visual = new VisualReportDto(),
                Speech = new SpeechReportDto(),
                Sentiment = new SentimentReportDto()
            };
        }
    }
}
