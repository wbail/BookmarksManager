using BookmarksManager.Domain.Entities;

namespace BookmarksManager.App.Contracts.Services;

public interface IChildValidUrlUpdateService
{
    Task<ChildValidUrl> SingleChangeIsValidStatusUpdate(string url);
    Task<IEnumerable<ChildValidUrl>> MultipleChangeIsValidStatusUpdate(IEnumerable<string> urls);
    Task InsertIntoDatabase(Dictionary<string, bool> urls);
}
