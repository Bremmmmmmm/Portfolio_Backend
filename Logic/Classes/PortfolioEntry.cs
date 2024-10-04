using Interface.Dtos;

namespace Logic.Classes;

public class PortfolioEntry(PortfolioEntryDto dto)
{
    public int Id { get; } = dto.Id;
    public string Title { get; } = dto.Title;
    public string Description { get; } = dto.Description;
    public string MediaUrl { get; } = dto.MediaUrl;

    public PortfolioEntryDto ToDto()
    {
        return new PortfolioEntryDto()
        {
            Id = Id,
            Title = Title,
            Description = Description,
            MediaUrl = MediaUrl
        };
    }
}