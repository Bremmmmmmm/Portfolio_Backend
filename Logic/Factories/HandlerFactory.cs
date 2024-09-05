using Interface.Interfaces.Logic;

namespace Logic.Factories;

public class HandlerFactory : IHandlerFactory
{
    private readonly IContainerFactory _containerFactory;
    
    public HandlerFactory(IContainerFactory containerFactory)
    {
        _containerFactory = containerFactory;
    }
}