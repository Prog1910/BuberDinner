using BuberDinner.Domain.Aggregates.MenuAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Aggregates.MenuAggregate.Entities;

public class MenuItem : Entity<MenuItemId>
{
	public string Name { get; } = string.Empty;
	public string Description { get; } = string.Empty;

	private MenuItem(
		MenuItemId menuItemId,
		string name,
		string description) : base(menuItemId)
	{
		Name = name;
		Description = description;
	}

	public static MenuItem Create(string name, string description) => new(
		MenuItemId.CreateUnique(),
		name,
		description);
}