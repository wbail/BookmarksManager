using BookmarksManager.App.Contracts.Services;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net;

namespace BookmarksManager.App.Services;

public class TestLinkService : ITestLinkService
{
    #region Private Fields

    private readonly IHttpClientService _httpClientService;
    private readonly ILogger<TestLinkService> _logger;
    private Stopwatch _stopWatch;
    private Dictionary<string, bool> _dictionary;

    #endregion

    #region Constructors

    public TestLinkService(IHttpClientService httpClientService, ILogger<TestLinkService> logger)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _dictionary = new Dictionary<string, bool>();
    }

    #endregion

    #region Public Methods

    public async Task<Dictionary<string, bool>> TestLinksAsync(IEnumerable<string> urls)
    {
        _logger.LogDebug($"Start: {DateTime.UtcNow}");
        _stopWatch = new Stopwatch();
        _stopWatch.Start();

        foreach (var url in urls)
        {
            await TestLinkAndAddToDictionary(url);
        }

        _stopWatch.Stop();
        _logger.LogDebug($"End: {DateTime.UtcNow}");
        _logger.LogInformation($"Time elapsed: {_stopWatch.Elapsed}");
        _stopWatch.Reset();

        return _dictionary;
    }

    public async Task<Dictionary<string, bool>> TestOneLinkAsync(string url)
    {
        await TestLinkAndAddToDictionary(url);

        return _dictionary;
    }

    #endregion

    #region Private Methods

    private async Task<HttpResponseMessage> TestLinkAsync(string url)
    {
        var result = await _httpClientService.GetAsync(url);

        return result;
    }

    private async Task TestLinkAndAddToDictionary(string url)
    {
        var result = await TestLinkAsync(url);

        if (IsSuccessStatusCode(result.StatusCode))
        {
            AddValueToDictionary(url, true);
        }
        else
        {
            AddValueToDictionary(url, false);
        }
    }

    private void AddValueToDictionary(string url, bool value)
    {
        _dictionary.Add(url, value);
    }

    private bool IsSuccessStatusCode(HttpStatusCode statusCode)
    {
        return (int)statusCode >= 200 && (int)statusCode < 400;
    }

    #endregion
}
