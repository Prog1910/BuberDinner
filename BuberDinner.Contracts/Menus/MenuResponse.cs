namespace BuberDinner.Contracts.Menus;

public sealed record MenuResponse(
	string Id,
	string Name,
	string Description,
	float? AverageRating,
	List<MenuSectionResponse> Sections,
	string HostId,
	List<string> DinnerIds,
	List<string> ReviewIds,
	DateTime CreatedDateTime,
	DateTime UpdatedDateTime);

public sealed record MenuSectionResponse(
	string Id,
	string Name,
	string Description,
	List<MenuItemResponse> Items);

public sealed record MenuItemResponse(
	string Id,
	string Name,
	string Description);