using Interface.Interfaces.Dal;
using Interface.Interfaces.Logic;
using Logic.Containers;

namespace Logic.Factories;

public class ContainerFactory : IContainerFactory
{
    private readonly IDalFactory _dalFactory;
    
    public ContainerFactory(IDalFactory dalFactory)
    {
        _dalFactory = dalFactory;
    }
    public IPortfolioEntryContainer BuildPortfolioEntryContainer()
    {
        return new PortfolioEntryContainer(_dalFactory);
    }
}