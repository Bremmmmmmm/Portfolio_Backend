using DataAccess.Database;
using Interface.Config;
using Interface.Interfaces.Dal;

namespace DataAccess.Factories;

public class DalFactory : IDalFactory
{
    private readonly IConfigLoader _configLoader;
    
    public DalFactory(IConfigLoader configLoader)
    {
        _configLoader = configLoader;
    }

    public IPortfolioEntryDal BuildPortfolioEntryDal()
    {
        return new PortfolioEntryDal(_configLoader.GetConfig<DbConf>().ConnectionString);
    }
}