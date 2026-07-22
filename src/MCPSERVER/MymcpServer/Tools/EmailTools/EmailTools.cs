using Microsoft.AspNetCore.Components.Forms;
using ModelContextProtocol;
using Microsoft.Extensions.AI;
using ModelContextProtocol.Server;
using Microsoft.Graph;

[McpServerToolType]
public class EmployeeTools
{
  [McpServerTool(Name = "GetEmployee")]
public async Task<string> GetEmployee(int employeeId)
{
    await Task.Delay(100); // Simulate async work

    return "Employee: Sarah";
}
}



