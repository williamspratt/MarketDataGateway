using DataValidationService.Services;
using DataValidationService.Model.Dto;
using DataValidationService.Model;

namespace MarketDataGatewayTests.FxDataTests
{
    public class ExtremeDataTest
    {
        private IRepositoryService<IMarketDataFx> _repositoryService;

        [SetUp]
        public void Setup()
        {
            this._repositoryService = new RepositoryService();
        }

        [Test]
        public void ExtremeBidGBPUSD()
        {
            this._repositoryService = new RepositoryService();

            string errorDescription;
            IMarketDataFx marketDataFx = new MarketDataFx(true, "GBPUSD", 1m, 0.5);

            IMarketDataFx? response = _repositoryService.CreateMarketData(marketDataFx, out errorDescription);

            if (response != null && String.IsNullOrWhiteSpace(errorDescription)) { Assert.Pass(); }
            else { Assert.Fail(); }
        }
        [Test]
        public void ExtremeAskGBPEUR()
        {
            this._repositoryService = new RepositoryService();

            string errorDescription;
            IMarketDataFx marketDataFx = new MarketDataFx(false, "GBPEUR", Decimal.MaxValue, Double.MaxValue);

            IMarketDataFx? response = _repositoryService.CreateMarketData(marketDataFx, out errorDescription);

            if (response != null && String.IsNullOrWhiteSpace(errorDescription)) { Assert.Pass(); }
            else { Assert.Fail(); }
        }
        [Test]
        public void ExtremeBidIRRGBP()
        {
            this._repositoryService = new RepositoryService();

            string errorDescription;
            IMarketDataFx marketDataFx = new MarketDataFx(true, "IRRGBP", 0.000019m, 1);

            IMarketDataFx? response = _repositoryService.CreateMarketData(marketDataFx, out errorDescription);

            if (response != null && String.IsNullOrWhiteSpace(errorDescription)) { Assert.Pass(); }
            else { Assert.Fail(); }
        }
    }
}