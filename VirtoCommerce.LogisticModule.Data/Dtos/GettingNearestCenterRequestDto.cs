using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.LogisticModule.Data.Dtos
{
    /// <summary>
    /// Request for receiving the nearest fulfillment center
    /// </summary>
    public class GettingNearestCenterRequestDto
    {
        public GettingNearestCenterRequestDto()
        {
            ProductIds = new List<string>();
        }
        
        public string City { get; set; }

        public string StateProvince { get; set; }

        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public string PostalCode { get; set; }

        public IEnumerable<string> ProductIds { get; set; }
    }
}
