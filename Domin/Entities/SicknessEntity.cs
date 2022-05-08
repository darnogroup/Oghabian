using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class SicknessEntity
    {
        public string SicknessId { set; get; } = Guid.NewGuid().ToString();
        public string SicknessTitle { set; get; }
        public string SicknessImagePath { set; get; }
        public IEnumerable<FoodEntity> Food { set; get; }
    }
}
