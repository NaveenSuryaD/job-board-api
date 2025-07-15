using JobBoardApi.Models;
using JobBoardApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.Controllers
{
    [ApiController]
    [Route("api/job-posts/{jobId}/apply")]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ApplicationsController(IApplicationService service, IWebHostEnvironment env)
        {
            _applicationService = service;
            _webHostEnvironment = env;
        }

        // Apply to a job with resume file ---- POST: api/job-posts/{jobId}/apply
        /// <summary>
        /// Apply to a job with resume file
        /// </summary>
        /// <param name="jobId">ID of the job post</param>
        /// <param name="application">Application details</param>
        /// <returns>Created application</returns>
        /// <response code="201">If the application is created successfully</response>
        /// <response code="400">If the application is null or invalid</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ApplyToJob(int jobId, [FromForm] ApplicationRequest application)
        {
            var ResumeFile = application.Resume;
            var ApplicantName = application.ApplicantName;
            var ApplicantEmail = application.ApplicantEmail;
            var ApplicantPhone = application.ApplicantPhone;
            var ApplicantMessage = application.ApplicantMessage;

            // Validate required fields
            if (string.IsNullOrEmpty(ApplicantName) || string.IsNullOrEmpty(ApplicantEmail))
            {
                return BadRequest("Applicant name and email are required.");
            }
            if (ApplicantEmail.Length > 100)
            {
                return BadRequest("Applicant email is too long.");
            }
            if (ApplicantPhone.Length > 15)
            {
                return BadRequest("Applicant phone number is too long.");
            }
            if (ApplicantMessage.Length > 500)
            {
                return BadRequest("Applicant message is too long.");
            }
            if (ResumeFile == null || ResumeFile.Length == 0)
            {
                return BadRequest("Resume file is required.");
            }
            if (ResumeFile.Length > 5 * 1024 * 1024) // Limit resume file size to 5MB
            {
                return BadRequest("Resume file size exceeds the limit of 5MB.");
            }

            // Validate job post exists (replace with service/repository call)
            var jobExists = await _applicationService.JobPostExistsAsync(jobId);
            if (!jobExists)
            {
                return NotFound("Job post not found.");
            }

            var allowedExtensions = new[] { ".pdf", ".docx" };
            var fileExtension = Path.GetExtension(ResumeFile.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(fileExtension))
            {
                return BadRequest("Invalid resume file format. Only PDF and DOCX are allowed.");
            }

            // Save the file 
            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "resumes", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await ResumeFile.CopyToAsync(stream);
            }

            // Save application to DB using service
            var newApplication = await _applicationService.ApplyToJobAsync(jobId, application, $"/resumes/{fileName}");

            return Ok(new
            {
                message = "Application submitted successfully",
                resumePath = newApplication.ResumeFilePath
            });
        }

        // Get all applications for a job post ---- GET: api/job-posts/{jobId}/applications
        /// <summary>
        /// Get all applications for a job post
        /// </summary>
        /// <param name="jobId">ID of the job post</param>
        /// <returns>List of applications for the specified job post</returns>
        /// <response code="200">Returns the list of applications</response>
        /// <response code="404">If the job post with the specified ID does not exist</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("/api/job-posts/{jobId}/applications")]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplicationsForJob(int jobId)
        { 
            var jobExists = await _applicationService.JobPostExistsAsync(jobId);
            if (!jobExists)
            {
                return NotFound("Job post not found.");
            }

            var applications = await _applicationService.GetApplicationsForJobAsync(jobId);
            return Ok(applications);
        }
    }
}


