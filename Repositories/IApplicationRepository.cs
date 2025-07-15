using JobBoardApi.Models;

namespace JobBoardApi.Repositories
{
    public interface IApplicationRepository
    {
        Task<Application> ApplyToJobAsync(int jobpostId, ApplicationRequest application, string resumeFilePath);
        Task<IEnumerable<Application>> GetApplicationsForJobAsync(int jobpostId);
    }
}