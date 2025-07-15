# JobBoardApi

A .NET Web API for managing job postings and applications.

## Features
- CRUD operations for job posts
- Apply to jobs with resume upload
- Application management
- Entity Framework Core with migrations

## Getting Started

1. **Install dependencies:**
   - [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
   - (Optional) [EF Core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

2. **Database setup:**
   - Run migrations:
     ```sh
     dotnet ef database update
     ```

3. **Run the API:**
   ```sh
   dotnet run
   ```

4. **API Endpoints:**
   - `GET /api/jobs` - List all jobs
   - `POST /api/job-posts/{jobId}/apply` - Apply to a job with resume
   - `GET /api/job-posts/{jobId}/applications` - List applications for a job

## Development
- Update models and run migrations as needed:
  ```sh
  dotnet ef migrations add <MigrationName>
  dotnet ef database update
  ```

## License
MIT
