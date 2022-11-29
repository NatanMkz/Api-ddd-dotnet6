using Api.Application.Menus.Commands.CreateMenu;
using Api.Contracts.Menus;
using Api.Domain.Menu;
using Mapster;
using MenuSection = Api.Domain.Menu.Entities.MenuSection;
using MenuItem = Api.Domain.Menu.Entities.MenuItem;

namespace Api.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenurequest Request, string HostId), CreateMenuCommand>()
        .Map(dest => dest.HostId, src => src.HostId)
        .Map(dest => dest, src => src.Request);

        config.NewConfig<Menu, MenuResponse>().Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.AverageRating, src => src.AverageRating)
        .Map(dest => dest.HostId, src => src.HostId.Value)
        .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinners => dinners.Value))
        .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuReview => menuReview.Value));


        config.NewConfig<MenuSection, MenuSectionResponse>().Map(dest => dest.Id, src => src.Id.Value);
        config.NewConfig<MenuItem, MenuItemResponse>().Map(dest => dest.Id, src => src.Id.Value);
    }
}