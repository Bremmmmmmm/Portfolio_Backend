using Interface.Interfaces.Logic;
using Logic.Factories;
using Tests.Mocks;

namespace Tests.Factories;

[TestClass]
public class HandlerFactoryTest
{
    private IContainerFactory _containerFactory = null!;
    
    [TestInitialize]
    public void Initialize()
    {
        _containerFactory = new ContainerFactory(new MockFactory());
    }
    
    [TestMethod]
    public void ConstructorTest()
    {
        //arrange
        //act
        var handlerFactory = new HandlerFactory(_containerFactory);
        //assert
        Assert.IsNotNull(handlerFactory);
    }
    
    [TestMethod]
    public void BuildFilmHandlerTest()
    {
        //arrange
        var handlerFactory = new HandlerFactory(_containerFactory);
        //act
        var portfolioEntryHandler = handlerFactory.BuildPortfolioEntryHandler();
        //assert
        Assert.IsNotNull(portfolioEntryHandler);
    }
}