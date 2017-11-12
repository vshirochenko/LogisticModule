﻿using System;
using GoogleMaps.LocationServices;
using Moq;
using VirtoCommerce.Domain.Commerce.Services;
using VirtoCommerce.InventoryModule.Data.Repositories;
using VirtoCommerce.LogisticModule.Data.Dtos;
using VirtoCommerce.LogisticModule.Data.Services;
using Xunit;

namespace VirtoCommerce.LogisticModule.Tests
{
    public class LogisticModuleServiceTests
    {
        private readonly ILogisticService _LogisticService;

        private readonly Mock<IInventoryRepository> _inventoryRepositoryMock;
        private readonly Mock<ICommerceService> _commerceServiceMock;
        private readonly Mock<ILocationService> _googleServiceMock;

        public LogisticModuleServiceTests()
        {
            _inventoryRepositoryMock = new Mock<IInventoryRepository>();
            _commerceServiceMock = new Mock<ICommerceService>();
            _googleServiceMock = new Mock<ILocationService>();

            _LogisticService = new LogisticServiceImpl(
                _inventoryRepositoryMock.Object, 
                _commerceServiceMock.Object,
                _googleServiceMock.Object
            );
        }

        [Fact]
        public void GetNearestCenter_Request_Null_ThrowsException()
        {
            // ARRANGE 
            GettingNearestCenterRequestDto request = null;

            // ACT
            Assert.Throws<ArgumentNullException>(() => _LogisticService.GetNearestFulfillmentCenter(request));
        }

        [Fact]
        public void GetNearestCenter_GetInventories_WasCalled()
        {
            // ARRANGE
            GettingNearestCenterRequestDto request = new GettingNearestCenterRequestDto();
            _inventoryRepositoryMock.Setup(x => x.Inventories);

            // ACT
            _LogisticService.GetNearestFulfillmentCenter(request);

            // ASSERT
            _inventoryRepositoryMock.Verify(x => x.Inventories, Times.Once);
        }

        [Fact]
        public void GetNearestCenter_GetAllFulfillmentCenters_WasCalled()
        {
            // ARRANGE
            GettingNearestCenterRequestDto request = new GettingNearestCenterRequestDto();
            _commerceServiceMock.Setup(x => x.GetAllFulfillmentCenters());

            // ACT
            _LogisticService.GetNearestFulfillmentCenter(request);

            // ASSERT
            _commerceServiceMock.Verify(x => x.GetAllFulfillmentCenters(), Times.Once);
        }

        [Fact]
        public void GetDistanceBetweenTwoAddresses_GoogleService_GetLocation_WasCalledTwice()
        {
            // ARRANGE
            string postalCodeFrom = "1", postalCodeTo = "2";
            _googleServiceMock.Setup(x => x.GetLatLongFromAddress(It.IsAny<string>()));

            // ACT
            double dist = _LogisticService.GetDistanceBetweenTwoAddresses(postalCodeFrom, postalCodeTo);

            // ASSERT
            _googleServiceMock.Verify(x => x.GetLatLongFromAddress(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
