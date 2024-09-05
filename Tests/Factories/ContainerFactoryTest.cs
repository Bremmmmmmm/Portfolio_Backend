using Interface.Interfaces.Dal;
using Logic.Factories;
using Tests.Mocks;

namespace Tests.Factories;

[TestClass]
public class ContainerFactoryTest
{
    private IDalFactory _dalFactory = null!;
    
    [TestInitialize]
    public void Initialize()
    {
        _dalFactory = new MockFactory();
    }
    
    [TestMethod]
    public void ConstructorTest()
    {
        //arrange
        //act
        var containerFactory = new ContainerFactory(_dalFactory);
        //assert
        Assert.IsNotNull(containerFactory);
    }
}