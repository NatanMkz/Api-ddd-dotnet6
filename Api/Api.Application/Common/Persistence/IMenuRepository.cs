using Api.Domain.Menu;

namespace Api.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}