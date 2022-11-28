using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Common.Models
{

    public abstract class ValueObject
    {
        public abstract IEnumerable<Object> GetEqualityComponents();
        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            var ValueObject = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(ValueObject.GetEqualityComponents());
        }

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents().Select(x => x?.GetHashCode() ?? 0).Aggregate((x, y) => x ^ y);
        }

        public bool Equals(ValueObject? other)
        {
            return Equals((object?)other);
        }

    }



    public class Price
    {
        public decimal Amount { get; private set; }

        public string Currency { get; private set; }

        public Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}