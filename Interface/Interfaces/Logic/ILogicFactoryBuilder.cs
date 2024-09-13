namespace Interface.Interfaces.Logic;

public interface ILogicFactoryBuilder
{
    public IHandlerFactory BuildHandlerFactory();
    public IContainerFactory BuildContainerFactory();
}