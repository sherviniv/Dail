namespace Dail.Application.Common.Models;

public class AppSettings
{
    public JwtSetting Jwt { get; set; } = default!;
    public string TimeZone { get; set; }
    public bool UseInMemoryDatabase { get; set; }
}