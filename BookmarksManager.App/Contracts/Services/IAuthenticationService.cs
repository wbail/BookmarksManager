using BookmarksManager.App.Models;

namespace BookmarksManager.App.Contracts.Services;

public interface IAuthenticationService
{
    Task<Tokens> Authenticate(UserAuthentication userAuthentication);
}
