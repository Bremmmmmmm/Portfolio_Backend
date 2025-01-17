namespace Interface.Dtos;

public class PortfolioEntryDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string MediaUrl { get; set; } = null!;
}