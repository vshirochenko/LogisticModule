using System;
using Moq;
using VirtoCommerce.InventoryModule.Data.Repositories;
using VirtoCommerce.LogisticModule.Data.Dtos;
using VirtoCommerce.LogisticModule.Data.Services;
using Xunit;

namespace VirtoCommerce.LogisticModule.Tests
{
    public class LogisticModuleServiceTests
    {
        private readonly ILogisticService _LogisticService;

        private readonly Mock<IInventoryRepository> _InventoryRepositoryMock;


        public LogisticModuleServiceTests()
        {
            _InventoryRepositoryMock = new Mock<IInventoryRepository>();

            _LogisticService = new LogisticServiceImpl(_InventoryRepositoryMock.Object);
            
        }

        [Fact]
        public void GetNearestCenter_Request_Null_ThrowsException()
        {
            // ARRANGE 
            NearestCenterRequestDto request = null;
            
            // ACT
            Assert.Throws<ArgumentNullException>(() => _LogisticService.GetNearestFulfillmentCenter(request));
        }

        [Fact]
        public void GetNearestCenter_GetInventories_WasCalled()
        {
            // ARRANGE
            NearestCenterRequestDto request = new NearestCenterRequestDto();
            _InventoryRepositoryMock.Setup(x => x.Inventories);

            // ACT
            _LogisticService.GetNearestFulfillmentCenter(request);

            // ASSERT
            _InventoryRepositoryMock.Verify(x => x.Inventories, Times.Once);
        }
    }
}
