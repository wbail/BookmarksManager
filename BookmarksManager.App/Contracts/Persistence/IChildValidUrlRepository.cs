using BookmarksManager.Domain.Entities;

namespace BookmarksManager.App.Contracts.Persistence;

public interface IChildValidUrlRepository : IAsyncRepository<ChildValidUrl>
{
    Task<ChildValidUrl> GetChildValidUrlByUrlAsync(string url);
    Task<IEnumerable<ChildValidUrl>> GetAllValidChildValidUrlAsync();
    Task<IEnumerable<ChildValidUrl>> GetAllInvalidChildValidUrlAsync();
}
