using LondonStock.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LondonStock.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrokerExchangeController : ControllerBase
    {
        private readonly ILogger<BrokerExchangeController> _logger;
        private readonly IAppDbContextFactory _appDbContextFactory;
        public BrokerExchangeController(ILogger<BrokerExchangeController> logger, IAppDbContextFactory appDbContextFactory)
        {
            _logger = logger;
            _appDbContextFactory = appDbContextFactory;
        }

        [HttpGet("Price/{tradeReference}")]
        public IEnumerable<BrokerResponse> Get(string tradeReference)
        {
            using (var db = _appDbContextFactory.CreateContext())
            {
                var result = db.Trades?
                    .Where(x => x.TradeReference == tradeReference)
                    .Include(s => s.Stock)
                    .Select(brokerresponse => new BrokerResponse()
                    {
                        TradeReference = brokerresponse.TradeReference,
                        BrokerId = brokerresponse.BrokerId,
                        Price = brokerresponse.Stock.Price,
                    }).ToList();
                
                return result??new List<BrokerResponse>();
            }
        }
    }


    public class BrokerResponse
    {
        public string? TradeReference { get; set; }
        public int? BrokerId { get; set; }
        public decimal? Price { get; set; }
    }
}