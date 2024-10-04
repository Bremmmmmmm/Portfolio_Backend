using Interface.Dtos;
using Interface.Interfaces.Logic;
using Interface.RequestBodies;

namespace Logic.Handlers;

public class PortfolioEntryHandler(IPortfolioEntryContainer portfolioEntryContainer) : IPortfolioEntryHandler
{
    public async Task CreatePortfolioEntry(PortfolioEntryBody body)
    {
        await portfolioEntryContainer.CreatePortfolioEntry(new PortfolioEntryDto
        {
            Id = body.Id,
            Title = body.Title,
            Description = body.Description,
            MediaUrl = body.MediaUrl
        });
    }

    public async Task<PortfolioEntryDto> GetPortfolioEntryById(int id)
    {
        return await portfolioEntryContainer.GetPortfolioEntryById(id);
    }

    public async Task<List<PortfolioEntryDto>> GetAllPortfolioEntries()
    {
        return await portfolioEntryContainer.GetAllPortfolioEntries();
    }

    public async Task UpdatePortfolioEntry(PortfolioEntryBody body)
    {
        await portfolioEntryContainer.UpdatePortfolioEntry(new PortfolioEntryDto
        {
            Id = body.Id,
            Title = body.Title,
            Description = body.Description,
            MediaUrl = body.MediaUrl
        });
    }
    
    public async Task DeletePortfolioEntry(int id)
    {
        await portfolioEntryContainer.DeletePortfolioEntry(id);
    }
}