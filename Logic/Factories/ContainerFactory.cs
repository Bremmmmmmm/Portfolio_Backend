using Interface.Interfaces.Dal;
using Interface.Interfaces.Logic;
using Logic.Containers;

namespace Logic.Factories;

public class ContainerFactory(IDalFactory dalFactory) : IContainerFactory
{
    public IPortfolioEntryContainer BuildPortfolioEntryContainer()
    {
        return new PortfolioEntryContainer(dalFactory);
    }
}