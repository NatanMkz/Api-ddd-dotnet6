using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using Api.Application.Common.Interfaces.Persistence;
using Api.Domain.Menu;
using Api.Domain.Menu.Entities;
using Api.Domain.Menu.ValueObjects;
using ErrorOr;
using MediatR;

namespace Api.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        // Cria Menu
        // Persiste o Menu
        // Retorna Menu
        await Task.CompletedTask;
        var menu = Menu.Create(
            request.Name,
            request.Description,
            HostId.CreateUnique(request.HostId),
            request.Sections.ConvertAll(section => MenuSection.Create(
                section.name,
                section.Description,
                section.Items.ConvertAll(item => MenuItem.Create(
                    item.Name,
                    item.Description
                ))
            ))
        );

        _menuRepository.Add(menu);
        return menu;
    }


}