using BookmarksManager.App.Contracts.Persistence;
using BookmarksManager.App.Contracts.Services;
using BookmarksManager.App.Models;
using BookmarksManager.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookmarksManager.App.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IOptions<JwtSettings> _jwtSettings;

    public AuthenticationService(IUserRepository userRepository, IOptions<JwtSettings> jwtSettings)
    {
        _userRepository = userRepository;
        _jwtSettings = jwtSettings;
    }

    public async Task<Tokens> Authenticate(UserAuthentication userAuthentication)
    {
        var isUserExists = await _userRepository.IsUserExists(userAuthentication.Username, userAuthentication.Password);

        if (!isUserExists)
        {
            return null;
        }

        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenKey = Encoding.UTF8.GetBytes(_jwtSettings.Value.Key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                 new Claim(ClaimTypes.Name, userAuthentication.Username)
            }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new Tokens { Token = tokenHandler.WriteToken(token) };
    }
}
