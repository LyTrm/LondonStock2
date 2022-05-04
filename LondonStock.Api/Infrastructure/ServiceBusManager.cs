using LondonStock.Infrastructure;

public class ServiceBusManager : BackgroundService
{
    private readonly ILogger<ServiceBusManager> _logger;
    private readonly IAppDbContextFactory _appDbContextFactory;

    public ServiceBusManager(ILogger<ServiceBusManager> logger, IAppDbContextFactory appDbContextFactory)
    {
        _logger = logger;
        _appDbContextFactory = appDbContextFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);


            ProcessMessage();


            await Task.Delay(1000, stoppingToken);
        }
    }

    private bool ProcessMessage()
    {
        var success = false;
        try
        {
            //start service bus client and processor
            //SubscriptionClient

            success = UpdateStockDetails("bodyOfSBMessage");


        }
        catch (Exception)
        {
            //exception handling
            //send message to exception queue
        }
        finally
        {
            //dispose service bus client and processor
        }
        return success;
    }

    public bool UpdateStockDetails(string bodyOfSBMessage)
    {

        try
        {
            //deserlialize body
            var stock = new StockTicker()
            {
                Symbol = "info from body",
                Price = Convert.ToDecimal("info from body"),
            };
            var payload = new Payload()
            {
                StockTicker = stock,
                Quantity = Convert.ToDecimal("info from body"),
                BrokerId = Convert.ToInt32("info from body")
            };
            using (var db = _appDbContextFactory.CreateContext())
            {
                //Logic to add/update Stock and Trade table

                db.Update(stock);
                db.Add(stock);
                db.SaveChanges();
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }

    internal class Payload
    {
        public StockTicker? StockTicker { get; set; }
        public decimal Quantity { get; set; }
        public int BrokerId { get; set; }

    }

    public class StockTicker
    {
        public string? Symbol { get; set; }
        public decimal Price { get; set; }
    }
}