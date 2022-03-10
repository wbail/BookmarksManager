using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookmarksManager.Persistence.Repositories;

public class ChildValidUrlRepository : BaseRepository<ChildValidUrl>, IChildValidUrlRepository
{
    private readonly BookmarksManagerDbContext _dbContext;

    public ChildValidUrlRepository(BookmarksManagerDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ChildValidUrl> GetChildValidUrlByUrlAsync(string url)
    {
        //var childValidUrl = from c in _dbContext.Child
        //                    join cv in _dbContext.ChildValidUrl
        //                        on c.Id equals cv.ChildId into grouping
        //                    from cv in grouping.DefaultIfEmpty()
        //                    where c.Url == url
        //                    select new ChildValidUrl 
        //                    { 
        //                        Id = cv.Id,
        //                        ChildId = cv.ChildId,
        //                        IsValid = cv.IsValid,
        //                        DateInserted = cv.DateInserted,
        //                        DateLastUpdate = cv.DateLastUpdate,
        //                        Child = c
        //                    };

        var childValidUrl = await _dbContext.ChildValidUrl
            .Where(x => x.Child.Url == url)
            .FirstOrDefaultAsync();

        return childValidUrl;
    }

    public async Task<IEnumerable<ChildValidUrl>> GetAllValidChildValidUrlAsync()
    {
        var validChildValidUrl = await _dbContext.ChildValidUrl
            .Where(x => x.IsValid == true)
            .ToListAsync();

        return validChildValidUrl;
    }

    public async Task<IEnumerable<ChildValidUrl>> GetAllInvalidChildValidUrlAsync()
    {
        var invalidChildValidUrl = await _dbContext.ChildValidUrl
            .Where(x => x.IsValid == false)
            .ToListAsync();

        return invalidChildValidUrl;
    }
}