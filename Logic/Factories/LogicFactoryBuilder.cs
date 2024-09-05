using Interface.Interfaces.Dal;
using Interface.Interfaces.Logic;

namespace Logic.Factories;

public class LogicFactoryBuilder : ILogicFactoryBuilder
{
    private readonly IDalFactory _dalFactory;
    
    public LogicFactoryBuilder(IDalFactory dalFactory)
    {
        _dalFactory = dalFactory;
    }
    
    public IHandlerFactory BuildHandlerFactory()
    {
        return new HandlerFactory(BuildContainerFactory());
    }
    
    public IContainerFactory BuildContainerFactory()
    {
        return new ContainerFactory(_dalFactory);
    }
}