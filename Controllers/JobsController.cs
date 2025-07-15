using JobBoardApi.Models;
using Microsoft.AspNetCore.Mvc;
using JobBoardApi.Services;

namespace JobBoardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobPostService _service;

        public JobsController(IJobPostService service)
        {
            _service = service;
        }

        // Get all job posts ---- api/jobs
        /// <summary>
        /// Get all job posts
        /// </summary>
        /// <returns>List of job posts</returns>
        /// <response code="200">Returns the list of job posts</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jobpost>>> GetAllJobs()
        {
            return await _service.GetAllJobsAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving job posts.");
                }
                return Ok(task.Result);
            });
        }

        // Get a specific job post by ID ---- api/jobs/{id}
        /// <summary>
        /// Get a job post by ID
        /// </summary>
        /// <param name="id">ID of the job post</param>
        /// <returns>Job post with the specified ID</returns>
        /// <response code="200">Returns the job post</response>
        /// <response code="404">If the job post with the specified ID does not exist</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Jobpost>> GetJobById(int id)
        {
            try
            {
                var job = await _service.GetJobByIdAsync(id);
                if (job == null)
                {
                    return NotFound();
                }
                return Ok(job);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving job post.");
            }
        }

        // Create a new job post ---- POST: api/jobs
        /// <summary>
        /// Create a new job post
        /// </summary>
        /// <param name="job">Job post to create</param>
        /// <returns>Created job post</returns>
        /// <response code="201">Returns the created job post</response>
        /// <response code="400">If the job post is null or invalid</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<Jobpost>> CreateJob(Jobpost job)
        {
            if (job == null)
            {
                return BadRequest("Job post cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(job.Title) || string.IsNullOrWhiteSpace(job.Description))
            {
                return BadRequest("Job title and description are required.");
            }
            if (string.IsNullOrWhiteSpace(job.CompanyName) || string.IsNullOrWhiteSpace(job.Location))
            {
                return BadRequest("Company name and location are required.");
            }
            job.PostedDate = DateTime.UtcNow; // Set the posted date to now
            await _service.CreateJobAsync(job); // Await only
            return NoContent();
        }

        // Update an existing job post ---- PUT: api/jobs/{id}
        /// <summary>
        /// Update an existing job post
        /// </summary>
        /// <param name="id">ID of the job post to update</param>
        /// <param name="updatedJob">Updated job post data</param>
        /// <returns>No content if successful</returns>
        /// <response code="204">If the update is successful</response>
        /// <response code="400">If the job post is null or invalid</response>
        /// <response code="404">If the job post with the specified ID does not exist</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, Jobpost updatedJob)
        {
            if (id != updatedJob.Id)
            {
                return BadRequest("Job ID mismatch.");
            }
            if (updatedJob == null)
            {
                return BadRequest("Job post cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(updatedJob.Title) || string.IsNullOrWhiteSpace(updatedJob.Description))
            {
                return BadRequest("Job title and description are required.");
            }
            if (string.IsNullOrWhiteSpace(updatedJob.CompanyName) || string.IsNullOrWhiteSpace(updatedJob.Location))
            {
                return BadRequest("Company name and location are required.");
            }
            await _service.UpdateJobAsync(updatedJob); // Await only
            return NoContent();
        }

        // Delete a job post ---- DELETE: api/jobs/{id}
        /// <summary>
        /// Delete a job post
        /// </summary>
        /// <param name="id">ID of the job post to delete</param>
        /// <returns>No content if successful</returns>
        /// <response code="204">If the deletion is successful</response>
        /// <response code="404">If the job post with the specified ID does not exist</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            await _service.DeleteJobAsync(id); // Await only
            return NoContent();
        }

        // Get the 5 most recent job posts (via stored procedure)
        /// <summary>
        /// Get the 5 most recent job posts
        /// </summary>
        /// <returns>List of the 5 most recent job posts</returns>
        /// <response code="200">Returns the list of the 5 most recent job posts</response>
        /// <response code="500">If there is an error retrieving the job posts</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("recent")]
        public async Task<ActionResult<IEnumerable<Jobpost>>> GetRecentJobs()
        {
            try
            {
                var recentJobs = await _service.GetRecentJobsAsync();
                return Ok(recentJobs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving recent job posts: {ex.Message}");
            }
        }
    }
}
