using BookmarksManager.Persistence;

namespace BookmarksManager.Api.Helpers;

public static class DatabaseInitializer
{
    public static void CreateDbIfNotExists(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<BookmarksManagerDbContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred creating the DB.");
            }
        }
    }
}
