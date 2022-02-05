using BookmarksManager.App.Contracts.Services;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BookmarksManager.App.Services;

public class TestLinkService : ITestLinkService
{
    private readonly IHttpClientService _httpClientService;
    private readonly ILogger<TestLinkService> _logger;

    public TestLinkService(IHttpClientService httpClientService, ILogger<TestLinkService> logger)
    {
        _httpClientService = httpClientService;
        _logger = logger;
    }

    public async Task<Dictionary<string, bool>> TestLinksAsync(IEnumerable<string> urls)
    {
        var dictionary = new Dictionary<string, bool>();

        _logger.LogInformation($"Start: {DateTime.UtcNow}");
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        foreach (var url in urls)
        {
            var result = await _httpClientService.GetAsync(url);

            if ((int)result.StatusCode < 400)
            {
                dictionary.Add(url, true);
            }
            else
            {
                dictionary.Add(url, false);
            }
        }

        stopWatch.Stop();
        _logger.LogInformation($"End: {DateTime.UtcNow}");
        _logger.LogInformation($"Time elapsed: {stopWatch.Elapsed}");

        return dictionary;
    }

    public async Task<Dictionary<string, bool>> TestOneLinkAsync(string url)
    {
        var result = await _httpClientService.GetAsync(url);

        var dictionary = new Dictionary<string, bool>();

        if ((int)result.StatusCode < 400)
        {
            dictionary.Add(url, true);
        }

        return dictionary;
    }
}
