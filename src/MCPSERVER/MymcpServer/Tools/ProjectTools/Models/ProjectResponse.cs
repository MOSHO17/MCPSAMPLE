using System.ComponentModel.DataAnnotations.Schema;

namespace MCPServerProject.Model
{

    public class Projects
    {
        public int? ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? AssignedTo { get; set; }
    }
    public class ProjectResponse
    {
        public int? ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? AssignedTo { get; set; }
    }
    public class CreateProjectRequest
    {
        public string ProjectName { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; }
        public string AssignedTo { get; set; }
    }
}
