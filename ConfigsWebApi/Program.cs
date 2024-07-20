using ConfigsApplication;
using ConfigsInfraestructure;

namespace ConfigsWebApi;

/// <summary>
/// The main entry point for the application.
/// </summary>
public class Program
{
    /// <summary>
    /// The main method that starts the application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Dependencies injections by layers.
        builder.Services.AddPresentation()
                        .AddApplication()
                        .AddInfraestructure(DecideWichEnviromentConfigurationToUse(builder))
                        ;

        var app = builder.Build();
        app.ConfigureWebApplication();
        app.Run();
    }

    /// <summary>
    /// Decides which environment configuration to use based on the application's environment.
    /// </summary>
    /// <param name="builder">The web application builder.</param>
    /// <returns>The appropriate configuration root.</returns>
    private static IConfigurationRoot DecideWichEnviromentConfigurationToUse(WebApplicationBuilder builder)
    {
        if (builder.Environment.IsDevelopment()) return BuildConfigurationRoot();

        return BuildConfigurationRoot("appsettings.json");
    }

    /// <summary>
    /// Builds the configuration root from the specified JSON file.
    /// </summary>
    /// <param name="fileName">The name of the JSON file to use. Defaults to "appsettings.Development.json".</param>
    /// <returns>The built configuration root.</returns>
    private static IConfigurationRoot BuildConfigurationRoot(string fileName = "appsettings.Development.json")
    {
        return new ConfigurationBuilder()
            .AddJsonFile(fileName)
            .Build();
    }
}