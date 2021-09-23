using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;

var httpFactory = HttpClientFactory.Create();

var minimalApiTest = Step.Create("minimal_api_test", httpFactory, async context =>
{
    var response = await context.Client.GetAsync("http://localhost:5293/all");

    return response.IsSuccessStatusCode ? Response.Ok(statusCode: (int)response.StatusCode) : Response.Fail(statusCode: (int)response.StatusCode);
});

var minimalApiScenario = ScenarioBuilder
    .CreateScenario("minimal_api_test", minimalApiTest)
    .WithWarmUpDuration(TimeSpan.FromSeconds(5))
    .WithLoadSimulations(Simulation.KeepConstant(24, TimeSpan.FromSeconds(60)));

NBomberRunner
    .RegisterScenarios(minimalApiScenario)
    .Run();