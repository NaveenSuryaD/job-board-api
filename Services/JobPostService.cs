using JobBoardApi.Models;
using JobBoardApi.Repositories;

namespace JobBoardApi.Services
{
    public class JobPostService : IJobPostService
    {
        private readonly IJobPostRepository _repo;

        public JobPostService(IJobPostRepository jobPostRepository)
        {
            _repo = jobPostRepository;
        }

        public Task<IEnumerable<Jobpost>> GetAllJobsAsync() => _repo.GetAllAsync();
        public Task<Jobpost?> GetJobByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<IEnumerable<Jobpost>> GetRecentJobsAsync() => _repo.GetRecentAsync();
        public Task CreateJobAsync(Jobpost job) => _repo.AddAsync(job);
        public Task UpdateJobAsync(Jobpost job) => _repo.UpdateAsync(job);
        public Task DeleteJobAsync(int jobId) => _repo.DeleteAsync(jobId);
    }
}