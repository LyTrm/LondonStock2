namespace LondonStock.Infrastructure
{
    public interface IAppDbContextFactory
    {
        AppDbContext CreateContext();
    }
}
