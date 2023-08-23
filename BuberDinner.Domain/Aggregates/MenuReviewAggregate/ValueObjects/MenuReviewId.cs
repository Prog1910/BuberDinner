using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.MenuReviewAggregate.ValueObjects;

public sealed class MenuReviewId : ValueObject
{
	public Guid Value { get; }

	private MenuReviewId(Guid value) => Value = value;

	public static MenuReviewId CreateUnique() => new(Guid.NewGuid());

	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}
}