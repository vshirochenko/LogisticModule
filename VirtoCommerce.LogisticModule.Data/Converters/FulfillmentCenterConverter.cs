using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.LogisticModule.Data.Dtos;

namespace VirtoCommerce.LogisticModule.Data.Converters
{
    public static class FulfillmentCenterConverter
    {
        public static FulfillmentCenterDto ToDto(this FulfillmentCenter center)
        {
            var retVal = new FulfillmentCenterDto();
            retVal.InjectFrom(center);
            return retVal;
        }
    }
}
