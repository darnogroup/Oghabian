using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class PropertyEntity
    {
       public string PropertyId { set; get; } = Guid.NewGuid().ToString();
        public string PropertyTitle { set; get; }
       public string PropertyValue { set; get; }
       public string FoodId { set; get; }
       public FoodEntity Food { set; get; }
    }
}
