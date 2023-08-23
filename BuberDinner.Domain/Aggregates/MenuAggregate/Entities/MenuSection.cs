using BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.MenuAggregate.Entities;

public class MenuSection : Entity<MenuSectionId>
{
	private readonly List<MenuItem> _items = new();
	public string Name { get; } = string.Empty;
	public string Description { get; } = string.Empty;

	public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

	private MenuSection(
		MenuSectionId menuSectionId,
		string name,
		string description,
		List<MenuItem> items) : base(menuSectionId)
	{
		Name = name;
		Description = description;
		_items = items;
	}

	public static MenuSection Create(
		string name,
		string description,
		List<MenuItem> items) => new(
		MenuSectionId.CreateUnique(),
		name,
		description,
		items);
}