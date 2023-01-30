using DataValidationService.Services;
using DataValidationService.Model.Dto;
using DataValidationService.Model;

namespace MarketDataGatewayTests.FxDataTests
{
    public class ExceptionalDataTest
    {
        private IRepositoryService<IMarketDataFx> _repositoryService;

        [SetUp]
        public void Setup()
        {
            this._repositoryService = new RepositoryService();
        }
        [Test]
        public void FutureTimeStamp()
        {
            this._repositoryService = new RepositoryService();

            string errorDescription;
            IMarketDataFx marketDataFx = new MarketDataFx(false, "GBPSEK", -1.11m, -12.5) { timeStamp = DateTime.Now.AddDays(7) };

            IMarketDataFx? response = _repositoryService.CreateMarketData(marketDataFx, out errorDescription);

            if (response == null && !String.IsNullOrWhiteSpace(errorDescription)) { Assert.Pass(); }
            else { Assert.Fail(); }
        }
        [Test]
        public void ExceptionalBid()
        {
            this._repositoryService = new RepositoryService();

            string errorDescription;
            IMarketDataFx marketDataFx = new MarketDataFx(false, "GBPSEK", -1.11m, -12.5);

            IMarketDataFx? response = _repositoryService.CreateMarketData(marketDataFx, out errorDescription);

            if (response == null && !String.IsNullOrWhiteSpace(errorDescription)) { Assert.Pass(); }
            else { Assert.Fail(); }
        }
        [Test]
        public void ExceptionalCurrencyWrong()
        {
            this._repositoryService = new RepositoryService();

            string errorDescription;
            IMarketDataFx marketDataFx = new MarketDataFx(false, "NOTACURRENCY", -1.11m, -12.5);

            IMarketDataFx? response = _repositoryService.CreateMarketData(marketDataFx, out errorDescription);

            if (response == null && !String.IsNullOrWhiteSpace(errorDescription)) { Assert.Pass(); }
            else { Assert.Fail(); }
        }
        [Test]
        public void ExceptionalCurrency6Chars()
        {
            this._repositoryService = new RepositoryService();

            string errorDescription;
            IMarketDataFx marketDataFx = new MarketDataFx(false, "ABCDEF", 10.2m, 20);

            IMarketDataFx? response = _repositoryService.CreateMarketData(marketDataFx, out errorDescription);

            if (response == null && !String.IsNullOrWhiteSpace(errorDescription)) { Assert.Pass(); }
            else { Assert.Fail(); }
        }
        [Test]
        public void ExceptionalNULL()
        {
            this._repositoryService = new RepositoryService();

            string errorDescription;
            IMarketDataFx marketDataFx = new MarketDataFx(false, null, 1.14m, 10);

            IMarketDataFx? response = _repositoryService.CreateMarketData(marketDataFx, out errorDescription);

            if (response == null && !String.IsNullOrWhiteSpace(errorDescription)) { Assert.Pass(); }
            else { Assert.Fail(); }
        }
        [Test]
        public void ExceptionalEmpty()
        {
            this._repositoryService = new RepositoryService();

            string errorDescription;
            IMarketDataFx marketDataFx = new MarketDataFx(false, String.Empty, 0, 0);

            IMarketDataFx? response = _repositoryService.CreateMarketData(marketDataFx, out errorDescription);

            if (response == null && !String.IsNullOrWhiteSpace(errorDescription)) { Assert.Pass(); }
            else { Assert.Fail(); }
        }
    }
}