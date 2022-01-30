using BookmarksManager.Infrastructure.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookmarksManager.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(options => configuration.GetSection("JwtSettings").Bind(options));

        var googleChromeBookmarksPathConfigurationWindows = new GoogleChromeBookmarksPathConfigurationWindows();
        googleChromeBookmarksPathConfigurationWindows.GoogleChromeBookmarksPathWindows = configuration["GoogleChromeBookmarksPathWindows"];
        services.AddSingleton(googleChromeBookmarksPathConfigurationWindows);

        var googleChromeBookmarksPathConfigurationLinux = new GoogleChromeBookmarksPathConfigurationLinux();
        googleChromeBookmarksPathConfigurationLinux.GoogleChromeBookmarksPathLinux = configuration["GoogleChromeBookmarksPathLinux"];
        services.AddSingleton(googleChromeBookmarksPathConfigurationLinux);

        return services;
    }
}
