using BuberDinner.Domain.Aggregates.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.HostAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.PriceAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Enums;

namespace BuberDinner.Domain.Aggregates.DinnerAggregate;

public sealed class Dinner : AggregateRoot<DinnerId>
{
	private readonly List<DinnerReservations> _reservations = new();

	public string Name { get; } = string.Empty;
	public string Description { get; } = string.Empty;
	public DateTime StartDateTime { get; }
	public DateTime EndDateTime { get; }
	public DinnerStatus Status { get; }
	public bool IsPublic { get; }
	public int MaxGuests { get; }
	public Price Price { get; }

	public IReadOnlyList<DinnerReservations> Reservations => _reservations.AsReadOnly();

	public HostId HostId { get; }
	public MenuId MenuId { get; }
	public string ImageUrl { get; } = string.Empty;
	public Location Location { get; }
	public DateTime CreatedDateTime { get; }
	public DateTime UpdatedDateTime { get; }

	public Dinner(
		DinnerId dinnerId,
		List<DinnerReservations> reservations,
		string name,
		string description,
		DateTime startDateTime,
		DateTime endDateTime,
		DinnerStatus status,
		bool isPublic,
		int maxGuests,
		Price price,
		HostId hostId,
		MenuId menuId,
		string imageUrl,
		Location location,
		DateTime createdDateTime,
		DateTime updatedDateTime) : base(dinnerId)
	{
		_reservations = reservations;
		Name = name;
		Description = description;
		StartDateTime = startDateTime;
		EndDateTime = endDateTime;
		Status = status;
		IsPublic = isPublic;
		MaxGuests = maxGuests;
		Price = price;
		HostId = hostId;
		MenuId = menuId;
		ImageUrl = imageUrl;
		Location = location;
		CreatedDateTime = createdDateTime;
		UpdatedDateTime = updatedDateTime;
	}

	public static Dinner Create(
		List<DinnerReservations> reservations,
		string name,
		string description,
		DateTime startDateTime,
		DateTime endDateTime,
		DinnerStatus status,
		bool isPublic,
		int maxGuests,
		Price price,
		HostId hostId,
		MenuId menuId,
		string imageUrl,
		Location location) => new(
			DinnerId.CreateUnique(),
			reservations,
			name,
			description,
			startDateTime,
			endDateTime,
			status,
			isPublic,
			maxGuests,
			price,
			hostId,
			menuId,
			imageUrl,
			location,
			DateTime.UtcNow,
			DateTime.UtcNow);
}

public class Location
{
}

public class DinnerReservations
{
}