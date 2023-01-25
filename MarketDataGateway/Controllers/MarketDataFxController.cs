using Microsoft.AspNetCore.Mvc;
using MarketDataGateway;
using DataValidationService.Services;
using DataValidationService.Model;
using DataValidationService.Model.Dto;

namespace MarketDataGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketDataFxController : ControllerBase
    {
        private readonly ILogger<MarketDataFxController> _logger;
        private IRepositoryService<IMarketDataFx> _repositoryService;

        public MarketDataFxController(ILogger<MarketDataFxController> logger)
        {
            this._logger = logger;
            this._repositoryService = new RepositoryService();
        }


        // GET: api/<MarketDataFxController>
        [HttpGet]
        public IEnumerable<IMarketDataFx> Get()
        {
            this._logger.Log(LogLevel.Information, "Get all MarketDataFx");

            MarketDataFx ff = new MarketDataFx(true, "GBPUSD", 1.23m, 100000);

            //return _repositoryService.GetAllMarketData();

            return new MarketDataFx[] { ff };
        }

        // GET api/<MarketDataFxController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MarketDataFxController>
        [HttpPost]
        public void Post([FromBody] MarketDataFx value)
        {
            this._logger.Log(LogLevel.Information, "POST MarketDataFx");

            IMarketDataFx marketDataFx = _repositoryService.CreateMarketData(value, out string errorDescription);

            if (marketDataFx != null)
            {
                this._logger.Log(LogLevel.Information, $"SUCCESSFUL create MarketDataFx id={marketDataFx.id}");
                   
            }
            else
            {
                this._logger.Log(LogLevel.Error, $"FAILED create MarketDataFx {errorDescription}");

            }
        }

        // PUT api/<MarketDataFxController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MarketDataFxController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
