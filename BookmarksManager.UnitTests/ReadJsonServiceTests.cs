using BookmarksManager.App.Services;
using BookmarksManager.Infrastructure.Configurations;
using System.Threading.Tasks;
using Xunit;

namespace BookmarksManager.UnitTests;

public class ReadJsonServiceTests
{
    public ReadJsonServiceTests()
    {
        _googleChromeBookmarksPathConfigurationWindows = new GoogleChromeBookmarksPathConfigurationWindows();

        _googleChromeBookmarksPathConfigurationLinux = new GoogleChromeBookmarksPathConfigurationLinux();
    }

    private readonly GoogleChromeBookmarksPathConfigurationWindows _googleChromeBookmarksPathConfigurationWindows;
    private readonly GoogleChromeBookmarksPathConfigurationLinux _googleChromeBookmarksPathConfigurationLinux;

    [Fact]
    public async Task ReadJsonAsync_ReceiveTheCorrectFromAppSettings_ReturnsThePathWindows()
    {
        // Arrange
        _googleChromeBookmarksPathConfigurationWindows.GoogleChromeBookmarksPathWindows = "\\Google\\Chrome\\User Data\\Default\\Bookmarks";

        var readJsonService = new ReadJsonService(_googleChromeBookmarksPathConfigurationWindows, _googleChromeBookmarksPathConfigurationLinux);

        // Act
        var result = await readJsonService.ReadJsonAsync();

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact(Skip = "Needs to mock the string result")]
    public async Task ReadJsonAsync_ReceiveTheCorrectFromAppSettings_ReturnsThePathLinux()
    {
        // Arrange
        _googleChromeBookmarksPathConfigurationLinux.GoogleChromeBookmarksPathLinux = "~/.config/google-chrome/Default/Bookmarks";

        var readJsonService = new ReadJsonService(_googleChromeBookmarksPathConfigurationWindows, _googleChromeBookmarksPathConfigurationLinux);

        // Act
        var result = await readJsonService.ReadJsonAsync();

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}
