namespace JobBoardApi.Models
{
    public class Application
    {
        public int Id { get; set; }
        public int JobpostId { get; set; }
        public string ApplicantName { get; set; } = string.Empty;
        public string ApplicantPhone { get; set; } = string.Empty;
        public string ApplicantEmail { get; set; } = string.Empty;
        public string ApplicantMessage { get; set; } = string.Empty;
        public DateTime ApplicationDate { get; set; }
        public string ResumeFilePath { get; set; } = string.Empty; // URL or path to the resume file
        public string Status { get; set; } = "Pending"; // e.g., Pending, Accepted, Rejected 
        public Jobpost Jobpost { get; set; } = default!;

    }
}