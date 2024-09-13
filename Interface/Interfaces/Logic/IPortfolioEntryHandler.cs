using Interface.Dtos;
using Interface.RequestBodies;

namespace Interface.Interfaces.Logic;

public interface IPortfolioEntryHandler
{
    public Task CreatePortfolioEntry(PortfolioEntryBody body);
    public Task<PortfolioEntryDto> GetPortfolioEntryById(int id);
    public Task<List<PortfolioEntryDto>> GetAllPortfolioEntries();
    public Task UpdatePortfolioEntry(PortfolioEntryBody body);
    public Task DeletePortfolioEntry(int id);
}