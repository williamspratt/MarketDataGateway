using DataValidationService.Services;
using DataValidationService.Model.Dto;
using DataValidationService.Model;

namespace MarketDataGatewayTests.FxDataTests
{
    public class Tests
    {
        private IRepositoryService<IMarketDataFx> _repositoryService;

        [SetUp]
        public void Setup()
        {
            this._repositoryService = new RepositoryService();
        }

        [Test]
        public void Test1()
        {
            this._repositoryService = new RepositoryService();

            string errorDescription;
            IMarketDataFx marketDataFx = new MarketDataFx(true, "GBPUSD", 1.23m, 100000);

            IMarketDataFx response = _repositoryService.CreateMarketData(marketDataFx, out errorDescription);

            Assert.Pass();
        }
    }
}