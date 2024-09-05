using Interface.Interfaces.Dal;
using Logic.Factories;
using Tests.Mocks;

namespace Tests.Factories;

[TestClass]
public class LogicFactoryTest
{
    private IDalFactory _dalFactory = null!;
    
    [TestInitialize]
    public void Initialize()
    {
        _dalFactory = new MockFactory();
    }
    
    [TestMethod]
    public void BuildContainerFactoryTest()
    {
        //arrange
        var builder = new LogicFactoryBuilder(_dalFactory);
        //act
        var containerFactory = builder.BuildContainerFactory();
        //assert
        Assert.IsNotNull(containerFactory);
    }
    
    [TestMethod]
    public void BuildHandlerFactoryTest()
    {
        //arrange
        var builder = new LogicFactoryBuilder(_dalFactory);
        //act
        var handlerFactory = builder.BuildHandlerFactory();
        //assert
        Assert.IsNotNull(handlerFactory);
    }
}