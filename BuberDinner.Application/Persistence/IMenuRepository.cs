using BuberDinner.Domain.Aggregates.MenuAggregate;

namespace BuberDinner.Application.Persistence;

public interface IMenuRepository
{
	void Add(Menu menu);
}