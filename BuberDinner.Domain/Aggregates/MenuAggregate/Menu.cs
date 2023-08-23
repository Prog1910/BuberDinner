using BuberDinner.Domain.Aggregates.DinnerAggregate;
using BuberDinner.Domain.Aggregates.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.HostAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuAggregate.Entities;
using BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;

namespace BuberDinner.Domain.Aggregates.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
	private readonly List<MenuSection> _sections = new();
	private readonly List<DinnerId> _dinnerIds = new();
	private readonly List<MenuReviewId> _reviewIds = new();
	public string Name { get; } = string.Empty;
	public string Description { get; } = string.Empty;
	public AverageRating AverageRating { get; }

	public IReadOnlyList<MenuSection> Sections => _sections;

	public HostId HostId { get; }
	public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
	public IReadOnlyList<MenuReviewId> ReviewIds => _reviewIds.AsReadOnly();

	public DateTime CreatedDateTime { get; }
	public DateTime UpdatedDateTime { get; }

	private Menu(
		MenuId menuId,
		string name,
		string description,
		HostId hostId,
		List<MenuSection> sections,
		DateTime createdDateTime,
		DateTime updatedDateTime) : base(menuId)
	{
		Name = name;
		Description = description;
		AverageRating = AverageRating.Create();
		HostId = hostId;
		CreatedDateTime = createdDateTime;
		UpdatedDateTime = updatedDateTime;
		_sections = sections;
	}

	public static Menu Create(
		HostId hostId,
		string name,
		string description,
		List<MenuSection> sections) => new(
			MenuId.CreateUnique(),
			name,
			description,
			hostId,
			sections,
			DateTime.UtcNow,
			DateTime.UtcNow);

	public void AddDinner(Dinner dinner) => _dinnerIds.Add(dinner.Id);

	public void RemoveDinner(Dinner dinner) => _dinnerIds.Remove(dinner.Id);

	public void UpdateSection(MenuSection section) => _sections.Add(section);
}