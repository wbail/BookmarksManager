using BookmarksManager.App.Contracts.Services;
using BookmarksManager.Infrastructure.Configurations;

namespace BookmarksManager.App.Services;

public class ReadJsonService : IReadJsonService
{
    private readonly GoogleChromeBookmarksPathConfigurationWindows _googleChromeBookmarksPathConfigurationWindows;
    private readonly GoogleChromeBookmarksPathConfigurationLinux _googleChromeBookmarksPathConfigurationLinux;

    public ReadJsonService(GoogleChromeBookmarksPathConfigurationWindows googleChromeBookmarksPathConfigurationWindows, GoogleChromeBookmarksPathConfigurationLinux googleChromeBookmarksPathConfigurationLinux)
    {
        _googleChromeBookmarksPathConfigurationWindows = googleChromeBookmarksPathConfigurationWindows;
        _googleChromeBookmarksPathConfigurationLinux = googleChromeBookmarksPathConfigurationLinux;
    }

    public async Task<string> ReadJsonAsync()
    {
        var windows = await ReadJsonWindowsAsync();

        if (!string.IsNullOrEmpty(windows))
        {
            return windows;
        }

        return await ReadJsonLinuxAsync();
    }

    private async Task<string> ReadJsonLinuxAsync()
    {
        var file = string.Empty;

        if (string.IsNullOrEmpty(_googleChromeBookmarksPathConfigurationLinux.GoogleChromeBookmarksPathLinux))
        {
            return file;
        }

        try
        {
            file = await File.ReadAllTextAsync(_googleChromeBookmarksPathConfigurationLinux.GoogleChromeBookmarksPathLinux);
        }
        catch (Exception ex)
        {
            //
        }

        return file;

    }

    private async Task<string> ReadJsonWindowsAsync()
    {
        var file = string.Empty;

        if (string.IsNullOrEmpty(_googleChromeBookmarksPathConfigurationWindows.LocalAppData) || string.IsNullOrEmpty(_googleChromeBookmarksPathConfigurationWindows.GoogleChromeBookmarksPathWindows))
        {
            return file;
        }

        file = await File.ReadAllTextAsync(_googleChromeBookmarksPathConfigurationWindows.LocalAppData + _googleChromeBookmarksPathConfigurationWindows.GoogleChromeBookmarksPathWindows);

        return file;
    }
}
