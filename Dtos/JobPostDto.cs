
namespace JobBoardApi.Dtos;
public class JobPostDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CompanyName { get; set; }
    public string Location { get; set; }
    public DateTime PostedDate { get; set; }
    public string JobType { get; set; } // e.g., Full-time, Part-time, Contract
    public string SalaryRange { get; set; } // e.g., "50,000 - 70,000"
}