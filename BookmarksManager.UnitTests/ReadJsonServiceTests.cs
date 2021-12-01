using BookmarksManager.App.Services;
using BookmarksManager.Infrastructure.Configurations;
using System.Threading.Tasks;
using Xunit;

namespace BookmarksManager.UnitTests;

public class ReadJsonServiceTests
{
    public ReadJsonServiceTests()
    {
        _googleChromeBookmarksPathConfiguration = new GoogleChromeBookmarksPathConfiguration();
        _googleChromeBookmarksPathConfiguration.GoogleChromeBookmarksPath = "\\Google\\Chrome\\User Data\\Default\\Bookmarks";
    }

    private readonly GoogleChromeBookmarksPathConfiguration _googleChromeBookmarksPathConfiguration;

    [Fact]
    public async Task ReadJsonAsync_ReceiveTheCorrectFromAppSettings_ReturnsThePath()
    {
        var readJsonService = new ReadJsonService(_googleChromeBookmarksPathConfiguration);

        var result = await readJsonService.ReadJsonAsync();

        Assert.NotNull(result);
    }
}
