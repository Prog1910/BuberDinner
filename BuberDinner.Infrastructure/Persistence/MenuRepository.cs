using BuberDinner.Application.Persistence;
using BuberDinner.Domain.Aggregates.MenuAggregate;

namespace BuberDinner.Infrastructure.Persistence;

public sealed class MenuRepository : IMenuRepository
{
	private static readonly List<Menu> _menus = new();

	public void Add(Menu menu) => _menus.Add(menu);
}