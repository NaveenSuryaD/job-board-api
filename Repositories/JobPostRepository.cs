using JobBoardApi.Data;
using JobBoardApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApi.Repositories
{
    public class JobPostRepository : IJobPostRepository
    {
        private readonly AppDbContext _context;

        public JobPostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Jobpost>> GetAllAsync()
        {
            return await _context.JobPosts.ToListAsync();
        }
        public async Task<Jobpost?> GetByIdAsync(int id)
        {
            return await _context.JobPosts.FindAsync(id);
        }
        public async Task<IEnumerable<Jobpost>> GetRecentAsync()
        {
            return await _context.JobPosts
                .OrderByDescending(j => j.PostedDate)
                .Take(5)
                .ToListAsync();
        }
        public async Task AddAsync(Jobpost job)
        {
            _context.JobPosts.Add(job);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Jobpost job)
        {
            _context.JobPosts.Update(job);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var job = await GetByIdAsync(id);
            if (job != null)
            {
                _context.JobPosts.Remove(job);
                await _context.SaveChangesAsync();
            }
        }
    }
}