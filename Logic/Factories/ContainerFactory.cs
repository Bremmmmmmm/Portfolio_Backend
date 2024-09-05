using Interface.Interfaces.Dal;
using Interface.Interfaces.Logic;

namespace Logic.Factories;

public class ContainerFactory : IContainerFactory
{
    private readonly IDalFactory _dalFactory;
    
    public ContainerFactory(IDalFactory dalFactory)
    {
        _dalFactory = dalFactory;
    }
}