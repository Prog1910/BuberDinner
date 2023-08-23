using BuberDinner.Domain.Aggregates.BillAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.GuestAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.UserAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;

namespace BuberDinner.Domain.Aggregates.GuestAggregate;

public sealed class Guest : AggregateRoot<GuestId>
{
	private readonly List<DinnerId> _upcomingDinnerIds = new();
	private readonly List<DinnerId> _pastDinnerIds = new();
	private readonly List<DinnerId> _pendingDinnerIds = new();
	private readonly List<BillId> _billIds = new();
	private readonly List<MenuReviewId> _menuReviewIds = new();
	private readonly List<Rating> _ratings = new();

	public string FirstName { get; } = string.Empty;
	public string LastName { get; } = string.Empty;
	public string ProfileImage { get; } = string.Empty;
	public double AverageRating { get; }

	public UserId UserId { get; }
	public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
	public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
	public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
	public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
	public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
	public IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();

	public DateTime CreatedDateTime { get; }
	public DateTime UpdatedDateTime { get; }

	private Guest(
		GuestId guestId,
		List<DinnerId> upcomingDinnerIds,
		List<DinnerId> pastDinnerIds,
		List<DinnerId> pendingDinnerIds,
		List<BillId> billIds,
		List<MenuReviewId> menuReviewIds,
		List<Rating> ratings,
		string firstName,
		string lastName,
		string profileImage,
		double averageRating,
		UserId userId,
		DateTime createdDateTime,
		DateTime updatedDateTime) : base(guestId)
	{
		_upcomingDinnerIds = upcomingDinnerIds;
		_pastDinnerIds = pastDinnerIds;
		_pendingDinnerIds = pendingDinnerIds;
		_billIds = billIds;
		_menuReviewIds = menuReviewIds;
		_ratings = ratings;
		FirstName = firstName;
		LastName = lastName;
		ProfileImage = profileImage;
		AverageRating = averageRating;
		UserId = userId;
		CreatedDateTime = createdDateTime;
		UpdatedDateTime = updatedDateTime;
	}

	public static Guest Create(
		List<DinnerId> upcomingDinnerIds,
		List<DinnerId> pastDinnerIds,
		List<DinnerId> pendingDinnerIds,
		List<BillId> billIds,
		List<MenuReviewId> menuReviewIds,
		List<Rating> ratings,
		string firstName,
		string lastName,
		string profileImage,
		double averageRating,
		UserId userId) => new(
			GuestId.CreateUnique(),
			upcomingDinnerIds,
			pastDinnerIds,
			pendingDinnerIds,
			billIds,
			menuReviewIds,
			ratings,
			firstName,
			lastName,
			profileImage,
			averageRating,
			userId,
			DateTime.UtcNow,
			DateTime.UtcNow);
}