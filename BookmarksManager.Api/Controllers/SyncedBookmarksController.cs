using BookmarksManager.App.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookmarksManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SyncedBookmarksController : ControllerBase
{
    private readonly ILogger<SyncedBookmarksController> _logger;
    private readonly ILinkService _linkService;

    public SyncedBookmarksController(ILogger<SyncedBookmarksController> logger, ILinkService linkService)
    {
        _logger = logger;
        _linkService = linkService;
    }

    [HttpGet]
    public async Task<IEnumerable<string>> GetAllLinksAsync()
    {
        return await _linkService.GetAll();
    }
}
