using DataValidationService.Services;
using DataValidationService.Model.Dto;
using DataValidationService.Model;

namespace MarketDataGatewayTests.FxDataTests
{
    public class NormalDataTest
    {
        private IRepositoryService<IMarketDataFx> _repositoryService;

        [SetUp]
        public void Setup()
        {
            this._repositoryService = new RepositoryService();
        }

        [Test]
        public void NormalBidGBPUSD()
        {
            this._repositoryService = new RepositoryService();

            string errorDescription;
            IMarketDataFx marketDataFx = new MarketDataFx(true, "GBPUSD", 1.23m, 100000);

            IMarketDataFx? response = _repositoryService.CreateMarketData(marketDataFx, out errorDescription);

            if (response != null && String.IsNullOrWhiteSpace(errorDescription)) { Assert.Pass(); }
            else { Assert.Fail(); }
        }
        [Test]
        public void NormalAskGBPEUR()
        {
            this._repositoryService = new RepositoryService();

            string errorDescription;
            IMarketDataFx marketDataFx = new MarketDataFx(false, "GBPEUR", 1.14m, 90000);

            IMarketDataFx? response = _repositoryService.CreateMarketData(marketDataFx, out errorDescription);

            if (response != null && String.IsNullOrWhiteSpace(errorDescription)) { Assert.Pass(); }
            else { Assert.Fail(); }
        }
    }
}