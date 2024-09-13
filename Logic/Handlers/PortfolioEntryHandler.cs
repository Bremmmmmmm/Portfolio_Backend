using Interface.Dtos;
using Interface.Interfaces.Logic;
using Interface.RequestBodies;

namespace Logic.Handlers;

public class PortfolioEntryHandler : IPortfolioEntryHandler
{
    private readonly IPortfolioEntryContainer _portfolioEntryContainer;
    
    public PortfolioEntryHandler(IPortfolioEntryContainer portfolioEntryContainer)
    {
        _portfolioEntryContainer = portfolioEntryContainer;
    }
    
    public async Task CreatePortfolioEntry(PortfolioEntryBody body)
    {
        await _portfolioEntryContainer.CreatePortfolioEntry(new PortfolioEntryDto
        {
            Id = body.Id,
            Title = body.Title,
            Description = body.Description,
            MediaUrl = body.MediaUrl,
        });
    }

    public async Task<PortfolioEntryDto> GetPortfolioEntryById(int id)
    {
        return await _portfolioEntryContainer.GetPortfolioEntryById(id);
    }

    public async Task<List<PortfolioEntryDto>> GetAllPortfolioEntries()
    {
        return await _portfolioEntryContainer.GetAllPortfolioEntries();
    }

    public async Task UpdatePortfolioEntry(PortfolioEntryBody body)
    {
        await _portfolioEntryContainer.UpdatePortfolioEntry(new PortfolioEntryDto
        {
            Id = body.Id,
            Title = body.Title,
            Description = body.Description,
            MediaUrl = body.MediaUrl,
        });
    }
    
    public async Task DeletePortfolioEntry(int id)
    {
        await _portfolioEntryContainer.DeletePortfolioEntry(id);
    }
}