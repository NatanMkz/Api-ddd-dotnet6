namespace Api.Contracts.Menus;

public record MenuResponse(
    Guid Id, 
    string Name, 
    string Description, 
    float AverageRating, 
    List<MenuSectionResponse> Sections, 
    string HostId, 
    List<string> DinnerIds, 
    List<string> MenuReviewIds,
    DateTime CreatedDateTime, 
    DateTime UpdateDateTime);

public record MenuSectionResponse(
    Guid Id, 
    string Name, 
    string Description, 
    List<MenuItemResponse> Items);

public record MenuItemResponse(
    string Id, 
    string Name, 
    string Description);