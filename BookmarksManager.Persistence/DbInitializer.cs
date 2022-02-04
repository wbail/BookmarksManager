using Microsoft.EntityFrameworkCore;

namespace BookmarksManager.Persistence;

public static class DbInitializer
{
    public static void Initialize(BookmarksManagerDbContext bookmarksManagerDbContext)
    {
        bookmarksManagerDbContext.Database.EnsureCreated();
        bookmarksManagerDbContext.Database.Migrate();
    }
}
