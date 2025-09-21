using Azure.Identity;
using FeatureFlagApi;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

var builder = WebApplication.CreateBuilder(args);
//https://learn.microsoft.com/en-us/azure/azure-app-configuration/howto-targetingfilter

// Retrieve the endpoint
string endpoint = builder.Configuration.GetValue<string>("Endpoints:AppConfiguration")
    ?? throw new InvalidOperationException("The setting `Endpoints:AppConfiguration` was not found.");

// Load configuration from Azure App Configuration 
builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(new Uri(endpoint), new DefaultAzureCredential());
    options.UseFeatureFlags(options =>
    {
        options.SetRefreshInterval(TimeSpan.FromSeconds(30));
    });
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton<ITargetingContextAccessor, DemoTargetingContextAccessor>();
builder.Services.AddFeatureManagement()
    .WithTargeting<ITargetingContextAccessor>();

var app = builder.Build();

app.MapGet("/feature-flag", async (IFeatureManager featureManager) =>
{

    if (await featureManager.IsEnabledAsync("DemoTargetFeature"))
    {
        return Results.Ok("Feature DemoTargetFeature is enabled for you");
    }

    return Results.Ok("Feature DemoTargetFeature is disabled for you");
});


app.MapGet("/enabled-flags", async (IFeatureManagerSnapshot featureManager) =>
{

    var enabledFeatures = new List<string>();
    await foreach (var feature in featureManager.GetFeatureNamesAsync())
    {
        if (await featureManager.IsEnabledAsync(feature))
        {
            enabledFeatures.Add(feature);
        }
    }
    return Results.Ok(enabledFeatures);

});

app.Run();
