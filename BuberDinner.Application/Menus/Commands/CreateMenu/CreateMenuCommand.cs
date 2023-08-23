using BuberDinner.Domain.Aggregates.MenuAggregate;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public sealed record CreateMenuCommand(
	string HostId,
	string Name,
	string Description,
	List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;

public sealed record MenuSectionCommand(
	string Name,
	string Description,
	List<MenuItemCommand> Items);

public sealed record MenuItemCommand(string Name, string Description);