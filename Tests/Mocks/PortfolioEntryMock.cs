using Interface.Dtos;
using Interface.Interfaces.Dal;

namespace Tests.Mocks;

public class PortfolioEntryMock : IPortfolioEntryDal
{
    private readonly List<PortfolioEntryDto> _entries = new()
    {
        new PortfolioEntryDto
        {
            Id = 0,
            Title = "Test",
            Description = "Test",
            MediaUrl = "Test"
        }
    };
    
    public async Task CreatePortfolioEntry(PortfolioEntryDto portfolioEntryDto)
    {
        await Task.Run(() => _entries.Add(portfolioEntryDto));
    }

    public async Task<PortfolioEntryDto> GetPortfolioEntryById(int id)
    {
        return await Task.Run(() => _entries.FirstOrDefault(x => x.Id == id)) ?? throw new InvalidOperationException();
    }

    public async Task<List<PortfolioEntryDto>> GetAllPortfolioEntries()
    {
        return await Task.Run(() => _entries);
    }

    public async Task UpdatePortfolioEntry(PortfolioEntryDto portfolioEntryDto)
    {
        await Task.Run(() =>
        {
            var entry = _entries.FirstOrDefault(x => x.Id == portfolioEntryDto.Id);
            if (entry == null) return;
            entry.Title = portfolioEntryDto.Title;
            entry.Description = portfolioEntryDto.Description;
            entry.MediaUrl = portfolioEntryDto.MediaUrl;
        });
    }

    public async Task DeletePortfolioEntry(int id)
    {
        await Task.Run(() => _entries.RemoveAll(x => x.Id == id));
    }
}