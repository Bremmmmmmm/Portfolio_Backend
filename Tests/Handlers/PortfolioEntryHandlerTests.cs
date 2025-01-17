using Interface.Interfaces.Logic;
using Interface.RequestBodies;
using Logic.Factories;
using Logic.Handlers;
using MockFactory = Tests.Mocks.MockFactory;

namespace Tests.Handlers;

[TestClass]
public class PortfolioEntryHandlerTests
{
    private IPortfolioEntryContainer _portfolioEntryContainer = null!;
    private PortfolioEntryBody _portfolioEntryBody;
    
    [TestInitialize]
    public void Initialize()
    {
        var dalFactory = new MockFactory();
        _portfolioEntryContainer = new LogicFactoryBuilder(dalFactory).BuildContainerFactory().BuildPortfolioEntryContainer();
        _portfolioEntryBody = new PortfolioEntryBody
        {
            Id = 1,
            Title = "Title",
            Description = "Description",
            MediaUrl = "MediaUrl"
        };
    }
    
    [TestMethod]
    public void ConstructorTest()
    {
        //act
        var portfolioEntryHandler = new PortfolioEntryHandler(_portfolioEntryContainer);
        //assert
        Assert.IsNotNull(portfolioEntryHandler);
    }

    [TestMethod]
    public async Task CreatePortfolioEntryTest()
    {
        //arrange
        var portfolioEntryHandler = new PortfolioEntryHandler(_portfolioEntryContainer);
        //act
        await portfolioEntryHandler.CreatePortfolioEntry(_portfolioEntryBody);
        //assert
        var portfolioEntry = await portfolioEntryHandler.GetPortfolioEntryById(1);
        Assert.AreEqual(1, portfolioEntry.Id);
        Assert.AreEqual("Title", portfolioEntry.Title);
        Assert.AreEqual("Description", portfolioEntry.Description);
        Assert.AreEqual("MediaUrl", portfolioEntry.MediaUrl);
    }

    [TestMethod]
    public async Task GetPortfolioEntryByIdTest()
    {
        //arrange
        var portfolioEntryHandler = new PortfolioEntryHandler(_portfolioEntryContainer);
        //act
        var portfolioEntry = await portfolioEntryHandler.GetPortfolioEntryById(0);
        //assert
        Assert.AreEqual(0, portfolioEntry.Id);
        Assert.AreEqual("Test", portfolioEntry.Title);
        Assert.AreEqual("Test", portfolioEntry.Description);
        Assert.AreEqual("Test", portfolioEntry.MediaUrl);
    }
    
    [TestMethod]
    public async Task GetAllPortfolioEntriesTest()
    {
        //arrange
        var portfolioEntryHandler = new PortfolioEntryHandler(_portfolioEntryContainer);
        //act
        var portfolioEntries = await portfolioEntryHandler.GetAllPortfolioEntries();
        //assert
        Assert.AreEqual(1, portfolioEntries.Count);
        Assert.AreEqual(0, portfolioEntries[0].Id);
        Assert.AreEqual("Test", portfolioEntries[0].Title);
        Assert.AreEqual("Test", portfolioEntries[0].Description);
        Assert.AreEqual("Test", portfolioEntries[0].MediaUrl);
    }

    [TestMethod]
    public async Task UpdatePortfolioEntryTest()
    {
        //arrange
        var portfolioEntryHandler = new PortfolioEntryHandler(_portfolioEntryContainer);
        await portfolioEntryHandler.CreatePortfolioEntry(_portfolioEntryBody);
        _portfolioEntryBody.Title = "Title2";
        //act
        await portfolioEntryHandler.UpdatePortfolioEntry(_portfolioEntryBody);
        //assert
        var portfolioEntry = await portfolioEntryHandler.GetPortfolioEntryById(1);
        Assert.AreEqual("Title2", portfolioEntry.Title);
        Assert.AreEqual("Description", portfolioEntry.Description);
        Assert.AreEqual("MediaUrl", portfolioEntry.MediaUrl);
    }

    [TestMethod]
    public async Task DeletePortfolioEntryTest()
    {
        //arrange
        var portfolioEntryHandler = new PortfolioEntryHandler(_portfolioEntryContainer);
        await portfolioEntryHandler.CreatePortfolioEntry(_portfolioEntryBody);
        //act
        await portfolioEntryHandler.DeletePortfolioEntry(1);
        //assert
        await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
        {
            await portfolioEntryHandler.GetPortfolioEntryById(1);
        });
    }
}