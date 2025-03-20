using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Genesis.TechChallenge.FunctionalTests.Common;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
    where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
    }
}
