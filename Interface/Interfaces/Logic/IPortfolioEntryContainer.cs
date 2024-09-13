using Interface.Dtos;

namespace Interface.Interfaces.Logic;

public interface IPortfolioEntryContainer
{
    public Task CreatePortfolioEntry(PortfolioEntryDto body);
    public Task<PortfolioEntryDto> GetPortfolioEntryById(int id);
    public Task<List<PortfolioEntryDto>> GetAllPortfolioEntries();
    public Task UpdatePortfolioEntry(PortfolioEntryDto body);
    public Task DeletePortfolioEntry(int id);
}