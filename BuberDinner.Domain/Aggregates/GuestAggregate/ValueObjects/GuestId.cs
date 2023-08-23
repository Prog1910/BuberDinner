using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.GuestAggregate.ValueObjects;

public sealed class GuestId : ValueObject
{
	public Guid Value { get; }

	private GuestId(Guid value) => Value = value;

	public static GuestId CreateUnique() => new(Guid.NewGuid());

	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}
}