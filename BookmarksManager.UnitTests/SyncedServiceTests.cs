using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.App.Services;
using BookmarksManager.Infrastructure.Configurations;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BookmarksManager.UnitTests;

public class SyncedServiceTests
{
    public SyncedServiceTests()
    {
        _googleChromeBookmarksPathConfiguration = new GoogleChromeBookmarksPathConfiguration();
        _googleChromeBookmarksPathConfiguration.GoogleChromeBookmarksPath = "\\Google\\Chrome\\User Data\\Default\\Bookmarks";

        _readJsonService = new ReadJsonService(_googleChromeBookmarksPathConfiguration);

        _syncedRepositoryMock = new Mock<ISyncedRepository>();

        _syncedService = new SyncedService(_readJsonService, _syncedRepositoryMock.Object);
    }

    private readonly ReadJsonService _readJsonService;
    private readonly SyncedService _syncedService;
    private readonly GoogleChromeBookmarksPathConfiguration _googleChromeBookmarksPathConfiguration;
    private readonly Mock<ISyncedRepository> _syncedRepositoryMock;

    [Fact]
    public async Task GetAll_RootIsNotEmpty_ReturnsListOfSyncedLinks()
    {
        var result = await _syncedService.GetAllLinksAsync();

        Assert.True(result.Any());
    }
}
