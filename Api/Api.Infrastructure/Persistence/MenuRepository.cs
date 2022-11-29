using Api.Application.Common.Interfaces.Persistence;
using Api.Domain.Menu;

namespace Api.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new(); 
    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}