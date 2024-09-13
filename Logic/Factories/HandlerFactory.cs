using Interface.Interfaces.Logic;
using Logic.Handlers;

namespace Logic.Factories;

public class HandlerFactory : IHandlerFactory
{
    private readonly IContainerFactory _containerFactory;
    
    public HandlerFactory(IContainerFactory containerFactory)
    {
        _containerFactory = containerFactory;
    }
    
    public IPortfolioEntryHandler BuildPortfolioEntryHandler()
    {
        return new PortfolioEntryHandler(_containerFactory.BuildPortfolioEntryContainer());
    }
}