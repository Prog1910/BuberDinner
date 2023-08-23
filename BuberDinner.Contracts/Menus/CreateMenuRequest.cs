namespace BuberDinner.Contracts.Menus;

public sealed record CreateMenuRequest(
	string Name,
	string Description,
	List<MenuSection> Sections);

public sealed record MenuSection(
	string Name,
	string Description,
	List<MenuItem> Items);

public sealed record MenuItem(string Name, string Description);