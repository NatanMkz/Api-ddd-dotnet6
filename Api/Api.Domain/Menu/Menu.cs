using Api.Domain.Menu.Entities;
using Api.Domain.Menu.ValueObjects;
using Api.Domain.Models;

namespace Api.Domain.Menu;


public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new List<MenuSection>();
    private readonly List<DinnerId> _dinners = new List<DinnerId>();
    private readonly List<MenuReviewId> _menuReviewIds = new List<MenuReviewId>();
    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinners.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTIme { get; }
    public DateTime UpdateDateTime { get; }

    private Menu(MenuId menuId, string name, string description, HostId hostId, DateTime cratedDateTime, DateTime updateDateTime) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDateTIme = cratedDateTime;
        UpdateDateTime = updateDateTime;
    }

    public static Menu Create(string name, string description, HostId hostId)
    {
        return new(MenuId.CreateUnique(), name, description, hostId, DateTime.UtcNow, DateTime.UtcNow);
    }


}