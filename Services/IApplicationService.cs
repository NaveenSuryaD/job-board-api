using JobBoardApi.Models;

namespace JobBoardApi.Services
{
    public interface IApplicationService
    {
        Task<Application> SubmitApplicationAsync(int jobId, ApplicationRequest request, string resumeFilePath);
        Task<IEnumerable<Application>> GetApplicationsByJobIdAsync(int jobId);
        Task<bool> JobPostExistsAsync(int jobpostId);
        Task<Application> ApplyToJobAsync(int jobpostId, ApplicationRequest application, string resumeFilePath);
        Task<IEnumerable<Application>> GetApplicationsForJobAsync(int jobpostId);
    }
}