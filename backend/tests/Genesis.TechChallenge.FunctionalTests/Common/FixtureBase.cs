namespace Genesis.TechChallenge.FunctionalTests.Common;

public abstract class FixtureBase
{
    private CustomWebApplicationFactory<Program> WebApplicationFactory { get; set; }
    public ApiClient ApiClient { get; set; }

    protected FixtureBase()
    {
        WebApplicationFactory = new CustomWebApplicationFactory<Program>();
        ApiClient = new ApiClient(WebApplicationFactory.CreateClient());
    }
}