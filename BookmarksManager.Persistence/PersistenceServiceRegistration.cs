using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookmarksManager.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookmarksManagerDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("BookmarksManager")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ISyncedRepository, SyncedRepository>();
        services.AddScoped<IChildRepository, ChildRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
