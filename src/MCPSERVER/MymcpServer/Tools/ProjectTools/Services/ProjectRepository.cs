using MCPServerProject.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MCPServerProject.Repository
{
    public class ProjectRepository
    {
        private readonly IConfiguration _configuration;

        public ProjectRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));
        }

        public List<Projects> GetProjects()
        {
            List<Projects> projects = new();

            using SqlConnection con = GetConnection();

            SqlCommand cmd = new SqlCommand("USP_GetProjects", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Flag", 1);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                projects.Add(new Projects
                {
                    ProjectId = Convert.ToInt32(reader["ProjectId"]),
                    ProjectName = reader["ProjectName"].ToString(),
                    Description = reader["Description"].ToString(),
                    StartDate = Convert.ToDateTime(reader["StartDate"]),
                    EndDate = Convert.ToDateTime(reader["EndDate"]),
                    Status = reader["Status"].ToString(),
                    AssignedTo = reader["AssignedTo"].ToString()
                });
            }

            return projects;
        }
        public int CreateProject(ProjectResponse project)
        {
            using SqlConnection con = GetConnection();

            SqlCommand cmd = new SqlCommand("USP_CreateProject", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProjectName", project.ProjectName);
            cmd.Parameters.AddWithValue("@Description", project.Description);
            cmd.Parameters.AddWithValue("@StartDate", project.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", project.EndDate);
            cmd.Parameters.AddWithValue("@Status", project.Status);
            cmd.Parameters.AddWithValue("@AssignedTo", project.AssignedTo);

            con.Open();

            int projectId = Convert.ToInt32(cmd.ExecuteScalar());

            return projectId;
        }
    }
}
