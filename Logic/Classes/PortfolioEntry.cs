using Interface.Dtos;

namespace Logic.Classes;

public class PortfolioEntry
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string MediaUrl { get; set; }
    
    public PortfolioEntry(PortfolioEntryDto dto)
    {
        Id = dto.Id;
        Title = dto.Title;
        Description = dto.Description;
        MediaUrl = dto.MediaUrl;
    }
    
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