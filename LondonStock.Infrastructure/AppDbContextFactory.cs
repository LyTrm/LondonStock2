namespace LondonStock.Infrastructure
{
    public class AppDbContextFactory : IAppDbContextFactory
    {
        public AppDbContext CreateContext()
        {
            //To carete db connections etc
            return new AppDbContext();
        }
    }
}
