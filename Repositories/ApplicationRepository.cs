using JobBoardApi.Data;
using JobBoardApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApi.Repositories;

public class ApplicationRepository : IApplicationRepository
{
    private readonly AppDbContext _context;

    public ApplicationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Application> ApplyToJobAsync(int jobpostId, ApplicationRequest application, string resumeFilePath)
    {
        var newApplication = new Application
        {
            JobpostId = jobpostId,
            ApplicantName = application.ApplicantName,
            ApplicantEmail = application.ApplicantEmail,
            ResumeFilePath = resumeFilePath,
            ApplicantMessage = application.ApplicantMessage
        };

        _context.Applications.Add(newApplication);
        await _context.SaveChangesAsync();

        return newApplication;
    }

    public async Task<IEnumerable<Application>> GetApplicationsForJobAsync(int jobpostId)
    {
        return await _context.Applications
            .Where(a => a.JobpostId == jobpostId)
            .ToListAsync();
    }
}
