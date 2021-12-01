using BookmarksManager.App.Contracts.Services;
using BookmarksManager.Infrastructure.Configurations;

namespace BookmarksManager.App.Services;

public class ReadJsonService : IReadJsonService
{
    private readonly GoogleChromeBookmarksPathConfiguration _googleChromeBookmarksPathConfiguration;

    public ReadJsonService(GoogleChromeBookmarksPathConfiguration googleChromeBookmarksPathConfiguration)
    {
        _googleChromeBookmarksPathConfiguration = googleChromeBookmarksPathConfiguration;
    }

    public async Task<string> ReadJsonAsync()
    {
        return await File.ReadAllTextAsync(_googleChromeBookmarksPathConfiguration.LocalAppData + _googleChromeBookmarksPathConfiguration.GoogleChromeBookmarksPath);
    }
}
