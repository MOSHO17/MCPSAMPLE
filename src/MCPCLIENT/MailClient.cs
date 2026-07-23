using System.Data;
using Microsoft.Extensions;
using modelcontextprotocol.client;
namespace MCPClient
{
    [McpClientToolType]
    public class MailClient
    {
        [McpClientTool(Name = "SendMail")]
        public async Task<string> SendMail(string to, string subject, string body)
        {
            await Task.Delay(100); // Simulate async work

            return $"Mail sent to {to} with subject '{subject}' and body '{body}'";
        }
    }
}