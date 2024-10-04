using Interface.Dtos;
using Interface.Interfaces.Dal;
using Interface.Interfaces.Logic;

namespace Logic.Containers;

public class PortfolioEntryContainer(IDalFactory dalFactory) : IPortfolioEntryContainer
{
    private readonly IPortfolioEntryDal _portfolioEntryDal = dalFactory.BuildPortfolioEntryDal();

    public async Task CreatePortfolioEntry(PortfolioEntryDto body)
    {
        await _portfolioEntryDal.CreatePortfolioEntry(body);
    }
    
    public async Task<PortfolioEntryDto> GetPortfolioEntryById(int id)
    {
        return await _portfolioEntryDal.GetPortfolioEntryById(id);
    }

    public async Task<List<PortfolioEntryDto>> GetAllPortfolioEntries()
    {
        return await _portfolioEntryDal.GetAllPortfolioEntries();
    }

    public async Task UpdatePortfolioEntry(PortfolioEntryDto body)
    {
        await _portfolioEntryDal.UpdatePortfolioEntry(body);
    }
    
    public async Task DeletePortfolioEntry(int id)
    {
        await _portfolioEntryDal.DeletePortfolioEntry(id);
    }
}