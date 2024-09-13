using Interface.Dtos;

namespace Interface.Interfaces.Dal;

public interface IPortfolioEntryDal
{
    public Task CreatePortfolioEntry(PortfolioEntryDto portfolioEntryDto);
    public Task<PortfolioEntryDto> GetPortfolioEntryById(int id);
    public Task<List<PortfolioEntryDto>> GetAllPortfolioEntries();
    public Task UpdatePortfolioEntry(PortfolioEntryDto portfolioEntryDto);
    public Task DeletePortfolioEntry(int id);
}