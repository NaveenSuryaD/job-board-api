using Microsoft.EntityFrameworkCore;
using JobBoardApi.Models;

namespace JobBoardApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Jobpost> JobPosts { get; set; }
    public DbSet<Application> Applications => Set<Application>();
}