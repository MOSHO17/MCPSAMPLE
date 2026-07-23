using System.Data;
using Microsoft.Extensions;
using modelcontextprotocol.client;
using microsot.Extensions.resilience;
namespace MCPClient
{
    [MPCClientToolType]
    public class ProjectClient
    {
        public async Task InitializeClientAsync()
        {
            var mcpClient = new HttpClientTransport(new HttpClientTransport
            {
                endpoint = "asdasd",
                TransportMode = HttpTransportMode.StreamableHttp,
                Name = "PayrollMcpServer"
            });
            await using var client = await McpClient.CreateAsync(transport);
            var tools = await client.ListToolsAsync();
        }


    }
}
