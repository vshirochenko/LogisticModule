using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMaps.LocationServices;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Domain.Commerce.Services;
using VirtoCommerce.InventoryModule.Data.Repositories;
using VirtoCommerce.LogisticModule.Data.Converters;
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
        private readonly ILocationService _googleService;

        public LogisticServiceImpl(
            IInventoryRepository inventoryRepository, 
            ICommerceService commerceService, 
            ILocationService locationService
        )
        {
            _inventoryRepository = inventoryRepository;
            _commerceService = commerceService;
            _googleService = locationService;
        }

        /// <summary>
        /// Get nearest fulfillment center by given location
        /// </summary>
        /// <param name="centerRequest">Request with needed params to get nearest fulfillment center</param>
        /// <returns>Nearest fulfillment center</returns>
        public FulfillmentCenterDto GetNearestFulfillmentCenter(GettingNearestCenterRequestDto centerRequest)
        {
            if (centerRequest == null)
                throw new ArgumentNullException("centerRequest");

            var inventories = _inventoryRepository.Inventories;
            var allCenters = _commerceService.GetAllFulfillmentCenters()
                .Where(x => x.PostalCode == centerRequest.PostalCode);

            foreach (FulfillmentCenter center in allCenters)
            {
                var centerInventories = inventories.Where(x => x.FulfillmentCenterId == center.Id);
                bool allProductsExist = true;
                foreach (string productId in centerRequest.ProductIds)
                {
                    if (!centerInventories.Any(x => x.Sku == productId))
                    {
                        allProductsExist = false;
                        break;
                    }
                }
                if (allProductsExist)
                {
                    return center.ToDto();
                }
            }

            return null;
        }

        /// <summary>
        /// Finds distance between two locations by addresses (abstract definition, now it is postal code),
        /// because of Google api allows to find geographical location by postal code
        /// </summary>
        /// <param name="postalCodeFrom">Address of the first location</param>
        /// <param name="postalCodeTo">Address of the second location</param>
        /// <returns></returns>
        public double GetDistanceBetweenTwoAddresses(string postalCodeFrom, string postalCodeTo)
        {
            var locationFrom = _googleService.GetLatLongFromAddress("stub1");
            var locationTo= _googleService.GetLatLongFromAddress("stub2");

            // ToDo implementation! (now it's only to test)
            return 0.0; 
        }
    }
}
