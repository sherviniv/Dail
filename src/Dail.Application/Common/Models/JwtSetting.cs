namespace Dail.Application.Common.Models;

public class JwtSetting
{
    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public int ExpiryMinutes { get; set; } = 1;
}