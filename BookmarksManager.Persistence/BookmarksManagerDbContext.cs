using BookmarksManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookmarksManager.Persistence;

public class BookmarksManagerDbContext : DbContext
{
    public BookmarksManagerDbContext(DbContextOptions<BookmarksManagerDbContext> options)
        : base(options)
    {
    }

    public DbSet<BookmarkBar> BookmarkBar { get; set; }
    public DbSet<Child> Child { get; set; }
    public DbSet<MetaInfo> MetaInfo { get; set; }
    public DbSet<Other> Other { get; set; }
    public DbSet<Root> Root { get; set; }
    public DbSet<Roots> Roots { get; set; }
    public DbSet<Synced> Synced { get; set; }
}
