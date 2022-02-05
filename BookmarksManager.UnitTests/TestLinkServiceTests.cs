using BookmarksManager.App.Contracts.Services;
using BookmarksManager.App.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BookmarksManager.UnitTests;

public class TestLinkServiceTests
{
    #region Constructors

    public TestLinkServiceTests()
    {
        _httpClientServiceMock = new Mock<IHttpClientService>();
        _loggerMock = new Mock<ILogger<TestLinkService>>();

        _testLinkService = new TestLinkService(_httpClientServiceMock.Object, _loggerMock.Object);
    }

    #endregion

    #region Private Fields

    private readonly Mock<IHttpClientService> _httpClientServiceMock;
    private readonly Mock<ILogger<TestLinkService>> _loggerMock;
    private TestLinkService _testLinkService;

    #endregion

    #region Happy Path

    [Fact]
    public async Task TestLinksAsync_ValidList_ReturnsDictionary()
    {
        // Arrange
        var urls = GetUrls();

        _httpClientServiceMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage());

        // Act
        var result = await _testLinkService.TestLinksAsync(urls);

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.True(result.Count > 0);
        _httpClientServiceMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Exactly(7));
    }

    [Fact]
    public async Task TestLinksAsync_ValidLink_ReturnsDictionary()
    {
        // Arrange
        var url = "https://bail.dev";

        _httpClientServiceMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage());

        // Act
        var result = await _testLinkService.TestOneLinkAsync(url);

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        _httpClientServiceMock.Verify(x => x.GetAsync(url), Times.Once);
    }

    #endregion

    #region Sad Path

    [Fact]
    public async Task TestLinksAsync_EmptyList_ReturnsDictionary()
    {
        // Arrange
        var urls = new List<string>();

        _httpClientServiceMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage());

        // Act
        var result = await _testLinkService.TestLinksAsync(urls);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
        _httpClientServiceMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Never);
    }

    #endregion

    #region Private Methods

    private IEnumerable<string> GetUrls()
    {
        var urls = new List<string>();

        urls.Add($"https://bail.dev");

        for (int i = 0; i < 6; i++)
        {
            urls.Add($"https://testLink{i}.com/");
        }

        return urls;
    }

    #endregion
}
