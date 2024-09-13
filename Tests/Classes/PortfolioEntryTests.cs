using Interface.Dtos;
using Logic.Classes;

namespace Tests.Classes;

[TestClass]
public class PortfolioEntryTests
{
    private PortfolioEntryDto _portfolioEntryDto = null!;
    
    [TestInitialize]
    public void Initialize()
    {
        _portfolioEntryDto = new PortfolioEntryDto()
        {
            Id = 1,
            Title = "Test",
            Description = "Test",
            MediaUrl = "Test"
        };
    }
    
    [TestMethod]
    public void ConstructorTest()
    {
        // Act
        var portfolioEntry = new PortfolioEntry(_portfolioEntryDto);
        // Assert
        Assert.AreEqual(_portfolioEntryDto.Id, portfolioEntry.Id);
        Assert.AreEqual(_portfolioEntryDto.Title, portfolioEntry.Title);
        Assert.AreEqual(_portfolioEntryDto.Description, portfolioEntry.Description);
        Assert.AreEqual(_portfolioEntryDto.MediaUrl, portfolioEntry.MediaUrl);
    }
    
    [TestMethod]
    public void ToDtoTest()
    {
        // Arrange
        var portfolioEntry = new PortfolioEntry(_portfolioEntryDto);
        // Act
        var newPortfolioEntryDto = portfolioEntry.ToDto();
        // Assert
        Assert.AreEqual(_portfolioEntryDto.Id, newPortfolioEntryDto.Id);
        Assert.AreEqual(_portfolioEntryDto.Title, newPortfolioEntryDto.Title);
        Assert.AreEqual(_portfolioEntryDto.Description, newPortfolioEntryDto.Description);
        Assert.AreEqual(_portfolioEntryDto.MediaUrl, newPortfolioEntryDto.MediaUrl);
    }
}