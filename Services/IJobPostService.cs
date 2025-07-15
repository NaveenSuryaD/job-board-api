using JobBoardApi.Models;

namespace JobBoardApi.Services
{
    public interface IJobPostService
    {
        Task<IEnumerable<Jobpost>> GetAllJobsAsync();
        Task<Jobpost?> GetJobByIdAsync(int id);
        Task<IEnumerable<Jobpost>> GetRecentJobsAsync();
        Task CreateJobAsync(Jobpost job);
        Task UpdateJobAsync(Jobpost job);
        Task DeleteJobAsync(int id);
    }
}