using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Enum;

namespace Domin.Entities
{
    public class OrderEntity
    {
        public string OrderId { set; get; } = Guid.NewGuid().ToString();
        public DateTime DateTime { set; get; }
        public string Code { set; get; }
        public bool Close { set; get; }
        public ConditionEnum Condition { set; get; }
        public bool PaymentOnTheSpot { set;get; }
        public int Total { set; get; }
        public  string UserId { set; get; }
        public  UserEntity User { set; get; }
        public bool Discount { set; get; }
        public IEnumerable<OrderDetailEntity>Detail { set; get; }
    }
}
