using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class OrderDetailEntity
    {
        public string OrderDetailId { set; get; } = Guid.NewGuid().ToString();
        public string FoodId { set; get; }
        public bool Me { set; get; } = false;
        public FoodEntity Food { set; get; }
        public string OrderId { set; get; }
        public OrderEntity Order { set; get; }
        public int Price { set; get; }
        public int Count { set; get; }
      
    }
}
