using JobBoardApi.Models;

namespace JobBoardApi.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.JobPosts.Any())
            {
                context.JobPosts.AddRange(new List<Jobpost>
                {
                    new Jobpost
                    {
                        Title = "Software Engineer",
                        Description = "Develop and maintain software applications.",
                        CompanyName = "Tech Solutions Inc.",
                        Location = "Remote",
                        PostedDate = DateTime.Now,
                        EmploymentType = "Full-time"
                    },
                    new Jobpost
                    {
                        Title = "Data Analyst",
                        Description = "Analyze data and generate reports.",
                        CompanyName = "Data Insights Ltd.",
                        Location = "Chicago, IL",
                        PostedDate = DateTime.Now,
                        EmploymentType = "Contract"
                    },
                    new Jobpost
                    {
                        Title = "Full Stack .NET Developer",
                        CompanyName = "TechCorp Solutions",
                        Location = "New York, NY",
                        Description = "Build and maintain enterprise-level applications using .NET, React, and Azure.",
                        EmploymentType = "Full-time",
                        PostedDate = DateTime.UtcNow
                    },
                    new Jobpost
                    {
                        Title = "Junior Software Engineer",
                        CompanyName = "Startup Hub",
                        Location = "Austin, TX",
                        Description = "Entry-level role for fresh graduates. Work with senior devs and gain hands-on experience.",
                        EmploymentType = "Contract",
                        PostedDate = DateTime.UtcNow.AddDays(-3)
                    },
                    new Jobpost
                    {
                        Title = "Backend Engineer (C#)",
                        CompanyName = "CloudWorks Inc.",
                        Location = "Remote",
                        Description = "Develop REST APIs, work with SQL Server and integrate with microservices.",
                        EmploymentType = "Full-time",
                        PostedDate = DateTime.UtcNow.AddDays(-7)
                    }
                });
                context.SaveChanges();
            }
        }
    }
}

