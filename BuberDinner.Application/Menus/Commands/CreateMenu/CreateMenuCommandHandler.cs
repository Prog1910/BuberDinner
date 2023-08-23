using BuberDinner.Application.Persistence;
using BuberDinner.Domain.Aggregates.HostAggregate.ValueObjects;
using BuberDinner.Domain.Aggregates.MenuAggregate;
using BuberDinner.Domain.Aggregates.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public sealed class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
	private readonly IMenuRepository _menuRepository;

	public CreateMenuCommandHandler(IMenuRepository menuRepository)
	{
		_menuRepository = menuRepository;
	}

	public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
	{
		await Task.CompletedTask;

		var menu = Menu.Create(
			hostId: HostId.CreateUnique(),
			name: request.Name,
			description: request.Description,
			sections: request.Sections.ConvertAll(section => MenuSection.Create(
				section.Name,
				section.Description,
				section.Items.ConvertAll(item => MenuItem.Create(
					item.Name,
					item.Description)))));

		_menuRepository.Add(menu);

		return menu;
	}
}