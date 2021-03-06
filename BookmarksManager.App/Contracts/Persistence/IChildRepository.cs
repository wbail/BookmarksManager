using BookmarksManager.Domain.Entities;

namespace BookmarksManager.App.Contracts.Persistence;

public interface IChildRepository : IAsyncRepository<Child>
{
    Task<Child> GetChildByUrlAsync(string url);
}
