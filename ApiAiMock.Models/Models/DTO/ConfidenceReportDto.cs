namespace ApiAiMock.Models
{
    public class ConfidenceReportDto
    {
        public string SessionId { get; set; } = string.Empty;
        public double Score { get; set; }
        public VisualReportDto Visual { get; set; } = new();
        public SpeechReportDto Speech { get; set; } = new();
        public SentimentReportDto Sentiment { get; set; } = new();
    }

    public class VisualReportDto
    {
        public double EyeContactRatio { get; set; }
        public int Frames { get; set; }
    }

    public class SpeechReportDto
    {
        public double Wpm { get; set; }
        public int FillerCount { get; set; }
        public double AvgPauseMs { get; set; }
    }

    public class SentimentReportDto
    {
        public double Positive { get; set; }
        public double Neutral { get; set; }
        public double Negative { get; set; }
    }
}
