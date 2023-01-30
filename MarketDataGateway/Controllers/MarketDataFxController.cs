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
        private readonly IRepositoryService<IMarketDataFx> _repositoryService;

        public MarketDataFxController(ILogger<MarketDataFxController> logger)
        {
            this._logger = logger;
            this._repositoryService = Program.globalRepositoryService;
            
        }
        

        // GET: api/<MarketDataFxController>
        [HttpGet]
        public ActionResult<IEnumerable<IMarketDataFx>> Get()
        {
            this._logger.Log(LogLevel.Information, "Get all MarketDataFx");
            return Ok(_repositoryService.GetAllMarketData());
        }

        // GET api/<MarketDataFxController>/5
        [HttpGet("{id}")]
        public ActionResult<IMarketDataFx> Get(int id)
        {
            this._logger.Log(LogLevel.Information, $"Get MarketDataFx id={id}");

            IMarketDataFx? response = _repositoryService.GetMarketData(id);

            if (response == null) { return NotFound($"Could not find MarketDataFx id={id}"); }
            else { return Ok(response); }
        }

        // POST api/<MarketDataFxController>
        [HttpPost]
        public ActionResult<IMarketDataFx> Post([FromBody] MarketDataFx value)
        {
            this._logger.Log(LogLevel.Information, "POST MarketDataFx");

            IMarketDataFx? marketDataFx = _repositoryService.CreateMarketData(value, out string errorDescription);

            if (marketDataFx != null)
            {
                this._logger.Log(LogLevel.Information, $"SUCCESSFUL create MarketDataFx id={marketDataFx.id}");
                return Ok(marketDataFx);
            }
            else
            {
                this._logger.Log(LogLevel.Error, $"FAILED create MarketDataFx => {errorDescription}");
                return BadRequest($"FAILED create MarketDataFx => {errorDescription}");
            }


        }

        /*
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
        */
    }
}
