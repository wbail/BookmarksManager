namespace BookmarksManager.App.Contracts.Services;

public interface ILinkService
{
    Task<IEnumerable<string>> GetAll();
}
