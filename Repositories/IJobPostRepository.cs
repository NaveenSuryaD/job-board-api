using JobBoardApi.Models;

namespace JobBoardApi.Repositories
{
    public interface IJobPostRepository
    {
        Task<IEnumerable<Jobpost>> GetAllAsync();
        Task<Jobpost?> GetByIdAsync(int id);
        Task<IEnumerable<Jobpost>> GetRecentAsync();
        Task AddAsync(Jobpost job);
        Task UpdateAsync(Jobpost job);
        Task DeleteAsync(int id);
    }
}