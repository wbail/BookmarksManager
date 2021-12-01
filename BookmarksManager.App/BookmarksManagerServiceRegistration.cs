﻿using BookmarksManager.App.Contracts.Services;
using BookmarksManager.App.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookmarksManager.App;

public static class BookmarksManagerServiceRegistration
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IReadJsonService, ReadJsonService>();
        services.AddScoped<ISyncedService, SyncedService>();

        return services;
    }
}
