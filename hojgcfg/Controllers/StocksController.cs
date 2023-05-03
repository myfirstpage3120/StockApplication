using Hangfire;
using hojgcfg.Data;
using hojgcfg.Model;
using hojgcfg.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hojgcfg.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StocksController : ControllerBase
	{
        private readonly StockPricesDbContext _context;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public StocksController(StockPricesDbContext context ,IBackgroundJobClient backgroundJobClient)
        {
            _context = context;
            _backgroundJobClient = backgroundJobClient;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockPrice>>> GetStockPrices()
        {
            //uncomment this line if you want to use the stored procedure
            var stockPrices = await _context.stockPrices.FromSqlRaw("EXECUTE UpdateStockPrice991").ToListAsync();
            //when you run the application you will get the values but the new values will get updated after 1 min
            //var stockPrices = await _context.stockPrices.ToListAsync();
            _backgroundJobClient.Schedule(() => Console.WriteLine("hello nihal wel come back"), TimeSpan.FromSeconds(2));
            return Ok(stockPrices);
        }
    }
}
