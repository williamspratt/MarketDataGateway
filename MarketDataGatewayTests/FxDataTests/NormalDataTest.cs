using DataValidationService.Services;
using DataValidationService.Model.Dto;
using DataValidationService.Model;

namespace MarketDataGatewayTests.FxDataTests
{
    public class Tests
    {
        private IValidationService _validationService;

        [SetUp]
        public void Setup()
        {
            this._validationService = new ValidationService();
        }

        [Test]
        public void Test1()
        {
            this._validationService = new ValidationService();

            string errorDescription;
            IMarketDataFx marketDataFx = new MarketDataFx(Guid.NewGuid().ToString(), DateTime.Now, true, "GBPUSD", 1.23m, 100000);

            _validationService.ValidateMarketDataFx(marketDataFx, out errorDescription);

            Assert.Pass();
        }
    }
}