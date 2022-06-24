using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class DiscountEntity
    {
        public string DiscountId { set; get; } = Guid.NewGuid().ToString();
        public string DiscountCode { set; get; }
        public long DiscountPrice { set; get; }
        public string DiscountTitle { set; get; }
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
    }
}
