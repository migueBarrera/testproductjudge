using FreyaApi.Helpers;
using System.Security.Claims;

namespace ProductJudgeAPI.Extensions;

public class JwtSecurityTokenService
{
    private readonly string jwtToken;

    private const int EXPIRES_DAYS_TOKEN = 1;
    private const int EXPIRES_DAYS_REFRESH_TOKEN = 31;

    public JwtSecurityTokenService(IConfiguration configuration)
    {
        var token = configuration.GetValue<string>("Jwt:Key");

        ArgumentNullException.ThrowIfNull(token, nameof(token));

        jwtToken = token;
    }

    public string BuildToken()
    {
        return BuildToken(
            Enumerable.Empty<Claim>());
    }

    public string BuildRefreshToken()
    {
        return BuildRefreshToken(
           Enumerable.Empty<Claim>());
    }

    private string BuildToken(
        IEnumerable<Claim> claims)
    {
        return JwtSecurityTokenHelper.BuildToken(jwtToken, claims, EXPIRES_DAYS_TOKEN);
    }

    private string BuildRefreshToken(
        IEnumerable<Claim> claims)
    {
        return JwtSecurityTokenHelper.BuildToken(jwtToken, claims, EXPIRES_DAYS_REFRESH_TOKEN);
    }

    public bool ValidateToken(string refreshToken, out IEnumerable<Claim> claims)
    {
        if (JwtSecurityTokenHelper.ValidateToken(jwtToken, refreshToken, out claims))
        {
            var claimNameIdentifier = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (claimNameIdentifier != null && Guid.TryParse(claimNameIdentifier.Value, out var id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
