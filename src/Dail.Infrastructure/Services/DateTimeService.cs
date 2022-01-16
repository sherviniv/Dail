using Dail.Application.Common.Interfaces;
using Dail.Application.Common.Models;
using Microsoft.Extensions.Options;

namespace Dail.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    private readonly string _timeZoneId;
    public DateTimeService(IOptions<AppSettings> setting)
    {
        _timeZoneId = setting.Value.TimeZone;
    }

    public DateTime UTCNow
    {
        get
        {
            var timeZoneLocal = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(id: _timeZoneId));
            return TimeZoneInfo.ConvertTimeToUtc(timeZoneLocal, TimeZoneInfo.FindSystemTimeZoneById(id: _timeZoneId));
        }
    }
}