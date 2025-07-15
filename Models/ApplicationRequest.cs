using Microsoft.AspNetCore.Http;

namespace JobBoardApi.Models;

public class ApplicationRequest
{
    public string ApplicantName { get; set; } = string.Empty;
    public string ApplicantEmail { get; set; } = string.Empty;
    public string ApplicantPhone { get; set; } = string.Empty;
    public string ApplicantMessage { get; set; } = string.Empty;
    public IFormFile Resume { get; set; } = default!;
}