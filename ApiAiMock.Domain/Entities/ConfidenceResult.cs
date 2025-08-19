using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAiMock.Domain.Entities
{
    public class ConfidenceResult
    {
        public string SessionId { get; set; } = string.Empty;
        public double OverallScore { get; set; }
        public double EyeContactRatio { get; set; }
        public int AnalyzedFrames { get; set; }
        public double WordsPerMinute { get; set; }
        public int FillerWordCount { get; set; }
        public double AveragePauseDurationMs { get; set; }
        public double PositiveSentiment { get; set; }
        public double NeutralSentiment { get; set; }
        public double NegativeSentiment { get; set; }
    }
}
