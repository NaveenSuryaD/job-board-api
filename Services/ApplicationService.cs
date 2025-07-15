using JobBoardApi.Models;
using JobBoardApi.Repositories;
using JobBoardApi.Data;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApi.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _repository;
        private readonly AppDbContext _context;
        public ApplicationService(IApplicationRepository repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<bool> JobPostExistsAsync(int jobpostId)
        {
            return await _context.JobPosts.AnyAsync(j => j.Id == jobpostId);
        }

        public async Task<Application> SubmitApplicationAsync(int jobpostId, ApplicationRequest application, string resumeFilePath)
        {
            // Map to repository method
            return await _repository.ApplyToJobAsync(jobpostId, application, resumeFilePath);
        }

        public async Task<Application> ApplyToJobAsync(int jobpostId, ApplicationRequest application, string resumeFilePath)
        {
            // Map to repository method
            return await _repository.ApplyToJobAsync(jobpostId, application, resumeFilePath);
        }

        public async Task<IEnumerable<Application>> GetApplicationsForJobAsync(int jobpostId)
        {
            return await _repository.GetApplicationsForJobAsync(jobpostId);
        }

        public async Task<IEnumerable<Application>> GetApplicationsByJobIdAsync(int jobpostId)
        {
            return await _repository.GetApplicationsForJobAsync(jobpostId);
        }
    }
}