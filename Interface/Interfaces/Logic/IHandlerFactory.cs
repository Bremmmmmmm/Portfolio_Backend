namespace Interface.Interfaces.Logic;

public interface IHandlerFactory
{
    public IPortfolioEntryHandler BuildPortfolioEntryHandler();
    public IWebSocketHandler BuildWebSocketHandler();
}