using DataAccess.Database;
using Interface.Config;
using Interface.Interfaces.Dal;

namespace DataAccess.Factories;

public class DalFactory(IConfigLoader configLoader) : IDalFactory
{
    private readonly IConfigLoader _configLoader = configLoader;

    public IPortfolioEntryDal BuildPortfolioEntryDal()
    {
        return new PortfolioEntryDal(configLoader.GetConfig<DbConf>().ConnectionString);
    }
}