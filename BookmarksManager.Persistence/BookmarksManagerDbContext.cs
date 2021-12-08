using BookmarksManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookmarksManager.Persistence;

public class BookmarksManagerDbContext : DbContext
{
    public BookmarksManagerDbContext(DbContextOptions<BookmarksManagerDbContext> options)
        : base(options)
    {
        Database.MigrateAsync();
    }

    public DbSet<BookmarkBar> BookmarkBar { get; set; }
    public DbSet<Child> Child { get; set; }
    public DbSet<MetaInfo> MetaInfo { get; set; }
    public DbSet<Other> Other { get; set; }
    public DbSet<Root> Root { get; set; }
    public DbSet<Roots> Roots { get; set; }
    public DbSet<Synced> Synced { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookmarkBar>().HasNoKey();

        modelBuilder.Entity<Child>().HasKey(x => x.Id);
        modelBuilder.Entity<Child>().Ignore(x => x.MetaInfo);
        modelBuilder.Entity<Child>().Ignore(x => x.DateAdded);
        modelBuilder.Entity<Child>().Ignore(x => x.DateModified);
        
        modelBuilder.Entity<MetaInfo>().HasNoKey();
        
        modelBuilder.Entity<Other>().HasNoKey();
        
        modelBuilder.Entity<Root>().HasNoKey();
        modelBuilder.Entity<Root>().Ignore(x => x.Roots);

        modelBuilder.Entity<Roots>().HasNoKey();
        modelBuilder.Entity<Roots>().Ignore(x => x.BookmarkBar);
        modelBuilder.Entity<Roots>().Ignore(x => x.Other);
        modelBuilder.Entity<Roots>().Ignore(x => x.Synced);

        modelBuilder.Entity<Synced>().HasKey(x => x.Id);
        modelBuilder.Entity<Synced>().Ignore(x => x.DateAdded);
        modelBuilder.Entity<Synced>().Ignore(x => x.DateModified);
        modelBuilder.Entity<Synced>().HasMany(x => x.Children).WithOne(x => x.Synced);
    }

}
