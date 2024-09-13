namespace Interface.Interfaces.Dal;

public interface IDalFactory
{
    public IPortfolioEntryDal BuildPortfolioEntryDal();
}