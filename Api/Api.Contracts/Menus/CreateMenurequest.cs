

//using Api.Domain.Menu.Entities;

namespace Api.Contracts.Menus;

    public record CreateMenurequest(
        string Name,
        string Description,
        List<MenuSection> Sections
    );



    public record MenuSection(string name, string Description, List<MenuItem> Items);

    public record MenuItem(string Name, string Description);
    
