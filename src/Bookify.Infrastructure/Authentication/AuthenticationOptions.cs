namespace Bookify.Infrastructure.Authentication;

public sealed class AuthenticationOptions
{
    public string Audience { get; init; } = string.Empty;
    public string MetadaUrl { get; init; } = string.Empty;
    public bool RequireHttpsMetada { get; init; } 
    public string ValidIssuer { get; init; } = string.Empty;
}
