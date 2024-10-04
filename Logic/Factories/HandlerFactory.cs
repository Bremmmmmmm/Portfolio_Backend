using Interface.Interfaces.Logic;
using Logic.Handlers;

namespace Logic.Factories;

public class HandlerFactory(IContainerFactory containerFactory) : IHandlerFactory
{
    public IPortfolioEntryHandler BuildPortfolioEntryHandler()
    {
        return new PortfolioEntryHandler(containerFactory.BuildPortfolioEntryContainer());
    }
}