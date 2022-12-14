
using Api.Domain.Common.Models;

namespace Api.Domain.Menu.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; }

    private HostId(Guid value)
    {
        Value = value;
    }
    public static HostId CreateUnique(string hostId)
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
}