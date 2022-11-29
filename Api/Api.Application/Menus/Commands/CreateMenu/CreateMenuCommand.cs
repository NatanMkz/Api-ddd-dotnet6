using Api.Domain.Menu;
using ErrorOr;
using MediatR;

namespace Api.Application.Menus.Commands.CreateMenu;

 public record CreateMenuCommand(
        string Name,
        string Description,
        string HostId,
        List<MenuSectionCommand> Sections
    ) : IRequest<ErrorOr<Menu>>;



    public record MenuSectionCommand(string name, string Description, List<MenuItemCommand> Items);

    public record MenuItemCommand(string Name, string Description);