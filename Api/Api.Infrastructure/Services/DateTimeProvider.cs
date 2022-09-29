using Api.Application.Common.Interfaces.Services;

namespace Api.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}