using LogisticModule.Controllers.Api;
using Moq;
using VirtoCommerce.LogisticModule.Data.Dtos;
using VirtoCommerce.LogisticModule.Data.Services;
using Xunit;

namespace VirtoCommerce.LogisticModule.Tests
{
    /// <summary>
    /// Testing api of logistic module
    /// </summary>
    public class LogisticModuleControllerTests
    {
        private readonly Mock<ILogisticService> _logisticServiceMock;

        private readonly LogisticModuleController _logisticController;

        public LogisticModuleControllerTests()
        {
            _logisticServiceMock = new Mock<ILogisticService>();

            _logisticController = new LogisticModuleController(_logisticServiceMock.Object);
        }

        [Fact]
        public void GetNearestFulfillmentCenter_GetNearestCenter_WasCalled()
        {
            // ARRANGE
            GettingNearestCenterRequestDto request = new GettingNearestCenterRequestDto();
            _logisticServiceMock.Setup(x => x.GetNearestFulfillmentCenter(It.IsAny<GettingNearestCenterRequestDto>()));

            // ACT
            _logisticController.GetNearestFulfillmentCenter(request);

            // ASSERT
            _logisticServiceMock.Verify(x => x.GetNearestFulfillmentCenter(It.IsAny<GettingNearestCenterRequestDto>()), Times.Once);
        }
    }
}
