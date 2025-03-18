using System.IdentityModel.Tokens.Jwt;

namespace ProductJudgeMobile.Services;

public class SesionServices
{
    // Class-level variables for token keys
    private const string TokenKey = "token";
    private const string RefreshTokenKey = "refreshToken";

    /// <summary>
    /// Stores the session tokens (token and refresh token) securely.
    /// </summary>
    /// <param name="token">The JWT token to store.</param>
    /// <param name="refreshToken">The refresh token to store.</param>
    public async Task StoreSessionAsync(string token, string refreshToken)
    {
        await SecureStorage.SetAsync(TokenKey, token);
        await SecureStorage.SetAsync(RefreshTokenKey, refreshToken);
    }

    /// <summary>
    /// Retrieves the JWT token from secure storage.
    /// </summary>
    /// <returns>The stored JWT token, or null if not present.</returns>
    public async Task<string> GetTokenAsync()
    {
        return await SecureStorage.GetAsync(TokenKey) ?? string.Empty;
    }

    /// <summary>
    /// Retrieves the refresh token from secure storage.
    /// </summary>
    /// <returns>The stored refresh token, or null if not present.</returns>
    public async Task<string> GetRefreshTokenAsync()
    {
        return await SecureStorage.GetAsync(RefreshTokenKey) ?? string.Empty;
    }

    /// <summary>
    /// Clears the stored session tokens.
    /// </summary>
    public async Task ClearSessionAsync()
    {
        await SecureStorage.SetAsync(TokenKey, string.Empty);
        await SecureStorage.SetAsync(RefreshTokenKey, string.Empty);
    }

    /// <summary>
    /// Validates if the provided JWT token has expired.
    /// </summary>
    /// <param name="token">The JWT token to validate.</param>
    /// <returns>True if the token is expired, otherwise false.</returns>
    private bool IsTokenExpired(string token)
    {
        var jwtHandler = new JwtSecurityTokenHandler();
        if (jwtHandler.CanReadToken(token))
        {
            var jwtToken = jwtHandler.ReadJwtToken(token);
            return jwtToken.ValidTo < DateTime.UtcNow;
        }
        return false;
    }

    /// <summary>
    /// Checks if the JWT token is valid.
    /// </summary>
    /// <returns>True if the token is valid, otherwise false.</returns>
    public async Task<bool> IsTokenValidAsync()
    {
        var token = await GetTokenAsync();
        return !IsTokenExpired(token);
    }

    /// <summary>
    /// Checks if the refresh token is valid.
    /// </summary>
    /// <returns>True if the refresh token is valid, otherwise false.</returns>
    public async Task<bool> IsRefreshTokenValidAsync()
    {
        var refreshToken = await GetRefreshTokenAsync();
        // Assuming refresh tokens don't have expiration encoded like JWTs
        return !string.IsNullOrEmpty(refreshToken);
    }
}
