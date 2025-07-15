namespace JobBoardApi.Dtos;
public class JobPostResponseDto : JobPostDto
{
    public string CompanyLogoUrl { get; set; } // URL to the company's logo
    public string ContactEmail { get; set; } // Email for job applications or inquiries
    public string ApplicationUrl { get; set; } // URL to apply for the job
    public string[] RequiredSkills { get; set; } // List of skills required for the job
    public string[] PreferredQualifications { get; set; } // List of preferred qualifications
}