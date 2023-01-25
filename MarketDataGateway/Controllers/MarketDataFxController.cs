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

        private IRepositoryService<IMarketDataFx> _repositoryService;

        public MarketDataFxController()
        {
            
            this._repositoryService = new RepositoryService();
        }


        // GET: api/<MarketDataFxController>
        [HttpGet]
        public IEnumerable<IMarketDataFx> Get()
        {
            return _repositoryService.GetAllMarketData();

            //return new MarketDataFx[] { new MarketDataFx(0, DateTime.Now, true, "GBPUSD", 1.23m, 100000) };
            //return new string[] { "value1", "value2" };
        }

        // GET api/<MarketDataFxController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MarketDataFxController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
