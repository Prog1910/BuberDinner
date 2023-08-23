using BuberDinner.Domain.Aggregates.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.HostAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.UserAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;

namespace BuberDinner.Domain.Aggregates.HostAggregate;

public sealed class Host : AggregateRoot<HostId>
{
	private readonly List<MenuId> _menuIds = new();
	private readonly List<DinnerId> _dinnerIds = new();
	public string FirstName { get; } = string.Empty;
	public string LastName { get; } = string.Empty;
	public string ProfileImage { get; } = string.Empty;
	public AverageRating AverageRating { get; }

	public UserId UserId { get; }
	public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
	public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

	public DateTime CreatedDateTime { get; }
	public DateTime UpdatedDateTime { get; }

	private Host(
		HostId hostId,
		List<MenuId> menuIds,
		List<DinnerId> dinnerIds,
		string firstName,
		string lastName,
		string profileImage,
		AverageRating averageRating,
		UserId userId,
		DateTime createdDateTime,
		DateTime updatedDateTime) : base(hostId)
	{
		_menuIds = menuIds;
		_dinnerIds = dinnerIds;
		FirstName = firstName;
		LastName = lastName;
		ProfileImage = profileImage;
		AverageRating = averageRating;
		UserId = userId;
		CreatedDateTime = createdDateTime;
		UpdatedDateTime = updatedDateTime;
	}

	public static Host Create(
		List<MenuId> menuIds,
		List<DinnerId> dinnerIds,
		string firstName,
		string lastName,
		string profileImage,
		AverageRating averageRating,
		UserId userId) => new(
			HostId.CreateUnique(),
			menuIds,
			dinnerIds,
			firstName,
			lastName,
			profileImage,
			averageRating,
			userId,
			DateTime.UtcNow,
			DateTime.UtcNow);
}