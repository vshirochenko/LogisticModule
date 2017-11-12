using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMaps.LocationServices;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Domain.Commerce.Services;
using VirtoCommerce.InventoryModule.Data.Repositories;
using VirtoCommerce.LogisticModule.Data.Dtos;

namespace VirtoCommerce.LogisticModule.Data.Services
{
    /// <summary>
    /// Service for logistic operations (including paths between location etc...)
    /// </summary>
    public class LogisticServiceImpl : ILogisticService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ICommerceService _commerceService;

        public LogisticServiceImpl(IInventoryRepository inventoryRepository, ICommerceService commerceService)
        {
            _inventoryRepository = inventoryRepository;
            _commerceService = commerceService;
        }

        public FulfillmentCenterDto GetNearestFulfillmentCenter(NearestCenterRequestDto centerRequest)
        {
            if (centerRequest == null)
                throw new ArgumentNullException("centerRequest");
            var inventories = _inventoryRepository.Inventories;
            var allCenters = _commerceService.GetAllFulfillmentCenters();

            return null;
        }
    }
}
