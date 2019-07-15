using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthCheckTest
{
    public class GithubHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://github.com");
            if(response.IsSuccessStatusCode)
            {
                return HealthCheckResult.Healthy("Success!");
            }
            return HealthCheckResult.Unhealthy("Fail");
        }
    }
}