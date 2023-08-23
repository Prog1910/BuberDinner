using BuberDinner.Domain.Aggregates.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.GuestAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.HostAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;

namespace BuberDinner.Domain.Aggregates.MenuReviewAggregate;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
	public Rating Rating { get; }
	public string Comment { get; } = string.Empty;
	public HostId HostId { get; }
	public MenuId MenuId { get; }
	public GuestId GuestId { get; }
	public DinnerId DinnerId { get; }
	public DateTime CreatedDateTime { get; }
	public DateTime UpdatedDateTime { get; }

	private MenuReview(
		MenuReviewId menuReviewId,
		Rating rating,
		string comment,
		HostId hostId,
		MenuId menuId,
		GuestId guestId,
		DinnerId dinnerId,
		DateTime createdDateTime,
		DateTime updatedDateTime) : base(menuReviewId)
	{
		Rating = rating;
		Comment = comment;
		HostId = hostId;
		MenuId = menuId;
		GuestId = guestId;
		DinnerId = dinnerId;
		CreatedDateTime = createdDateTime;
		UpdatedDateTime = updatedDateTime;
	}

	public static MenuReview Create(
		Rating rating,
		string comment,
		HostId hostId,
		MenuId menuId,
		GuestId guestId,
		DinnerId dinnerId) => new(
			MenuReviewId.CreateUnique(),
			rating,
			comment,
			hostId,
			menuId,
			guestId,
			dinnerId,
			DateTime.UtcNow,
			DateTime.UtcNow);
}