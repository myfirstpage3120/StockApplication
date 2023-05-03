using hojgcfg.Data;
using hojgcfg.Model;

namespace hojgcfg.Services
{
    public interface ITimeService
    {
        void printNow();

    }
    public class TimeService : ITimeService
    {   
        private readonly ILogger<TimeService> _logger;
        private readonly StockPricesDbContext _dbContext;

        public TimeService(ILogger<TimeService> logger, StockPricesDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public void printNow()
        {   
            _logger.LogInformation(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            var tcs = _dbContext.stockPrices.Single(c => c.CompanyName == "TCS");
            // update tcs's stock price in the database
            Random rand = new Random();
            int randNum = rand.Next(200, 500);

            // update wipro's stock price in the database
            tcs.Price = randNum;

            _dbContext.SaveChanges();
            UpdateInfosys();
            UpdateTesla();
            UpdateInfobytes();
            UpdateAccenture();

            Console.WriteLine("\nTCS stock price: {0}", tcs.Price);
        }
        public void UpdateInfosys()
        {
            var Infosys = _dbContext.stockPrices.Single(c => c.CompanyName == "Infosys");
            // update tcs's stock price in the database
            Random rand = new Random();
            int randNum = rand.Next(200, 500);

            // update wipro's stock price in the database
            Infosys.Price = randNum;

            _dbContext.SaveChanges();

        }
        public void UpdateTesla()
        {
            var Tesla = _dbContext.stockPrices.Single(c => c.CompanyName == "Tesla");
            // update tcs's stock price in the database
            Random rand = new Random();
            int randNum = rand.Next(200, 500);

            // update wipro's stock price in the database
            Tesla.Price = randNum;

            _dbContext.SaveChanges();
            Console.WriteLine("\nTesla stock price: {0}", Tesla.Price);

        }
        public void UpdateAccenture()
        {
            var Accenture = _dbContext.stockPrices.Single(c => c.CompanyName == "Accenture");
            // update tcs's stock price in the database
            Random rand = new Random();
            int randNum = rand.Next(200, 500);

            // update wipro's stock price in the database
            Accenture.Price = randNum;

            _dbContext.SaveChanges();
            Console.WriteLine("\nAccenture stock price: {0}", Accenture.Price);

        }
        public void UpdateInfobytes()
        {
            var Infobytes = _dbContext.stockPrices.Single(c => c.CompanyName == "Infobytes");
            // update tcs's stock price in the database
            Random rand = new Random();
            int randNum = rand.Next(200, 500);

            // update wipro's stock price in the database
            Infobytes.Price = randNum;

            _dbContext.SaveChanges();
            Console.WriteLine("\nInfobytes stock price: {0}", Infobytes.Price);

        }
    }
}
