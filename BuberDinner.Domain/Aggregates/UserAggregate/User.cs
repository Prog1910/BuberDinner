using BuberDinner.Domain.Aggregates.UserAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
	public string FirstName { get; } = string.Empty;
	public string LastName { get; } = string.Empty;
	public string Email { get; } = string.Empty;
	public string Password { get; } = string.Empty;
	public DateTime CreatedDateTime { get; }
	public DateTime UpdatedDateTime { get; }

	private User(
		UserId userId,
		string firstName,
		string lastName,
		string email,
		string password,
		DateTime createdDateTime,
		DateTime updatedDateTime) : base(userId)
	{
		FirstName = firstName;
		LastName = lastName;
		Email = email;
		Password = password;
		CreatedDateTime = createdDateTime;
		UpdatedDateTime = updatedDateTime;
	}

	public static User Create(
		string firstName,
		string lastName,
		string email,
		string password) => new(
			UserId.CreateUnique(),
			firstName,
			lastName,
			email,
			password,
			DateTime.UtcNow,
			DateTime.UtcNow);
}