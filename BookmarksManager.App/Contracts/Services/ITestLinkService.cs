namespace BookmarksManager.App.Contracts.Services;

public interface ITestLinkService
{
    Task<Dictionary<string, bool>> TestLinksAsync(IEnumerable<string> urls);

    Task<Dictionary<string, bool>> TestOneLinkAsync(string url);
}
