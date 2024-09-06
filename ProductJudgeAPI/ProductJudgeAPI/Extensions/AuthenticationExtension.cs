using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProductJudgeAPI.Extensions;

public static class AuthenticationExtension
{
    public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<JwtSecurityTokenService>();

        var secret = config.GetSection("Jwt").GetSection("Key").Value;

        ArgumentNullException.ThrowIfNull(secret);

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.TokenValidationParameters = GetValidationParameters(Encoding.ASCII.GetBytes(secret));
        });

        return services;
    }

    private static TokenValidationParameters GetValidationParameters(byte[] key)
    {
        return new TokenValidationParameters()
        {
            ValidateLifetime = true, // Because there is no expiration in the generated token
            ValidateAudience = false, // Because there is no audiance in the generated token
            ValidateIssuer = false,   // Because there is no issuer in the generated token
            ValidIssuer = "Sample",
            ValidAudience = "Sample",
            IssuerSigningKey = new SymmetricSecurityKey(key) // The same key as the one that generate the token
        };
    }
}
