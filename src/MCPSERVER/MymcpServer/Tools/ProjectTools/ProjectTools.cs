using MCPServerProject.Model;
using MCPServerProject.Repository;
using Microsoft.Data.SqlClient;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Data;

namespace MCPServerProject.MCPTool
{
    [McpServerToolType]
    public class ProjectTools
    {
        private readonly ProjectRepository _repository;

        public ProjectTools(ProjectRepository repository)
        {
            _repository = repository;
        }

        [McpServerTool(Name = "get_projects")]
        [Description("Returns all projects from the database.")]
        public List<Projects> GetProjects()
        {
            var projects = _repository.GetProjects();

            return projects.Select(x => new Projects
            {
                ProjectId = x.ProjectId,
                ProjectName = x.ProjectName,
                Description = x.Description,
                Status = x.Status,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                AssignedTo = x.AssignedTo
            }).ToList();
        }

        [McpServerTool(Name = "create_project")]
        [Description("Creates a new project in SQL Server.")]
        public string CreateProject(CreateProjectRequest createProjectRequest)
        {
            ProjectResponse project = new ProjectResponse
            {
                ProjectName = createProjectRequest.ProjectName,
                Description = createProjectRequest.Description,
                StartDate = createProjectRequest.StartDate,
                EndDate = createProjectRequest.EndDate,
                Status = createProjectRequest.Status,
                AssignedTo = createProjectRequest.AssignedTo
            };

            int projectId = _repository.CreateProject(project);

            return $"Project created successfully. Project Id : {projectId}";
        }
    }
}
