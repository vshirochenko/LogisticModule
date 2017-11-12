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
    public class NearestCenterRequestDto
    {
        public NearestCenterRequestDto()
        {
            ProductIds = new List<string>();
        }

        public string PostalCode { get; set; }

        public IEnumerable<string> ProductIds { get; set; }
    }
}
