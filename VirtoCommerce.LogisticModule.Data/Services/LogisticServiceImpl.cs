using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.InventoryModule.Data.Repositories;
using VirtoCommerce.LogisticModule.Data.Dtos;

namespace VirtoCommerce.LogisticModule.Data.Services
{
    public class LogisticServiceImpl : ILogisticService
    {
        private readonly IInventoryRepository _InventoryRepository;

        public LogisticServiceImpl(IInventoryRepository inventoryRepository)
        {
            _InventoryRepository = inventoryRepository;
        }

        public FulfillmentCenterDto GetNearestFulfillmentCenter(NearestCenterRequestDto centerRequest)
        {
            if (centerRequest == null)
                throw new ArgumentNullException("centerRequest");
            var test = _InventoryRepository.Inventories;
            return null;
        }
    }
}
