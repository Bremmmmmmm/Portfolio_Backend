using Interface.Interfaces.Dal;

namespace Tests.Mocks;

public class MockFactory : IDalFactory
{
    public IPortfolioEntryDal BuildPortfolioEntryDal()
    {
        return new PortfolioEntryMock();
    }
}