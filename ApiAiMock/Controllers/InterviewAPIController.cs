using ApiAiMock.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ApiAiMock.Controllers
{
    /// <summary>
    /// Interview API for managing interview sessions
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class InterviewAPIController : ControllerBase
    {
        /// <summary>
        /// Get the current status of the Interview API
        /// </summary>
        /// <returns>Status information</returns>
        [HttpGet("status")]
        [ProducesResponseType(typeof(InterviewStatusResponse), 200)]
        public ActionResult<InterviewStatusResponse> GetStatus()
        {
            var response = new InterviewStatusResponse
            {
                Status = "Interview API is running",
                Timestamp = DateTime.UtcNow
            };
            
            return Ok(response);
        }

        /// <summary>
        /// Start a new interview session
        /// </summary>
        /// <param name="request">Interview start request containing candidate information</param>
        /// <returns>Session information</returns>
        [HttpPost("start")]
        [ProducesResponseType(typeof(StartInterviewResponse), 200)]
        [ProducesResponseType(400)]
        public ActionResult<StartInterviewResponse> StartInterview([FromBody] StartInterviewRequest request)
        {
            if (string.IsNullOrEmpty(request.CandidateName) || string.IsNullOrEmpty(request.Position))
            {
                return BadRequest("Candidate name and position are required.");
            }

            var sessionId = Guid.NewGuid().ToString();
            var response = new StartInterviewResponse
            {
                SessionId = sessionId,
                Message = "Interview session started successfully",
                Timestamp = DateTime.UtcNow,
                CandidateName = request.CandidateName,
                Position = request.Position
            };

            return Ok(response);
        }

        /// <summary>
        /// End an existing interview session
        /// </summary>
        /// <param name="request">Interview end request containing session information</param>
        /// <returns>Confirmation of session end</returns>
        [HttpPost("end")]
        [ProducesResponseType(typeof(EndInterviewResponse), 200)]
        [ProducesResponseType(400)]
        public ActionResult<EndInterviewResponse> EndInterview([FromBody] EndInterviewRequest request)
        {
            if (string.IsNullOrEmpty(request.SessionId))
            {
                return BadRequest("Session ID is required.");
            }

            var response = new EndInterviewResponse
            {
                Message = "Interview session ended successfully",
                Timestamp = DateTime.UtcNow,
                SessionId = request.SessionId
            };

            return Ok(response);
        }
    }
}
