using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.App.Contracts.Services;
using BookmarksManager.Domain.Entities;

namespace BookmarksManager.App.Services;

public class ChildValidUrlUpdateService : IChildValidUrlUpdateService
{
    private readonly IChildValidUrlRepository _childValidUrlRepository;
    private readonly IChildRepository _childRepository;

    public ChildValidUrlUpdateService(IChildValidUrlRepository childValidUrlRepository, IChildRepository childRepository)
    {
        _childValidUrlRepository = childValidUrlRepository;
        _childRepository = childRepository;
    }

    public async Task<ChildValidUrl> SingleChangeIsValidStatusUpdate(string url)
    {
        var childValidUrl = await ChangeIsValidStatusUpdate(url);

        return childValidUrl;
    }

    public async Task<IEnumerable<ChildValidUrl>> MultipleChangeIsValidStatusUpdate(IEnumerable<string> urls)
    {
        var childrenValidUrl = new List<ChildValidUrl>();

        foreach (var url in urls)
        {
            var childValidUrl = await ChangeIsValidStatusUpdate(url);

            childrenValidUrl.Add(childValidUrl);
        }

        return childrenValidUrl;
    }

    private async Task<ChildValidUrl> ChangeIsValidStatusUpdate(string url)
    {
        var childValidUrl = await GetByUrlAsync(url);

        if (childValidUrl != null)
        {
            childValidUrl.IsValid = !childValidUrl.IsValid;
            childValidUrl.DateLastUpdate = DateTime.UtcNow;
            await _childValidUrlRepository.UpdateAsync(childValidUrl);
        }
        
        return childValidUrl;
    }

    private async Task<ChildValidUrl> GetByUrlAsync(string url)
    {
        return await _childValidUrlRepository.GetChildValidUrlByUrlAsync(url);
    }

    public async Task InsertIntoDatabase(Dictionary<string, bool> urls)
    {
        foreach (var url in urls)
        {
            var child = await _childRepository.GetChildByUrlAsync(url.Key);

            var childValidUrl = new ChildValidUrl(Guid.NewGuid().ToString(), url.Value, child.Id, child, DateTime.UtcNow);

            await _childValidUrlRepository.AddAsync(childValidUrl);
        }
    }
}
