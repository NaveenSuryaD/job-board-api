namespace JobBoardApi.Models
{
    public class Jobpost
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime PostedDate { get; set; }
        public string EmploymentType { get; set; } = string.Empty; // e.g., Full-time, Part-time, Contract
    }
}