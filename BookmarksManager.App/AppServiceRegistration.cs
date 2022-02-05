using BookmarksManager.App.Contracts.Services;
using BookmarksManager.App.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookmarksManager.App;

public static class AppServiceRegistration
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IReadJsonService, ReadJsonService>();
        services.AddScoped<ISyncedService, SyncedService>();
        services.AddScoped<ILinkService, LinkService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IHttpClientService, HttpClientService>();
        services.AddScoped<ITestLinkService, TestLinkService>();
        services.AddSingleton<HttpClient>();

        return services;
    }
}
