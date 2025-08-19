namespace ApiAiMock.Models.DTO
{
    public class StartInterviewRequest
    {
        public string CandidateName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string? InterviewType { get; set; }
    }

    public class EndInterviewRequest
    {
        public string SessionId { get; set; } = string.Empty;
        public string? Feedback { get; set; }
        public int? Rating { get; set; }
    }

    public class InterviewStatusResponse
    {
        public string Status { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }

    public class StartInterviewResponse
    {
        public string SessionId { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string CandidateName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
    }

    public class EndInterviewResponse
    {
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string? SessionId { get; set; }
    }
}