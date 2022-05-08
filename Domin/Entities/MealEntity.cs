using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class MealEntity
    {
        public string MealId { set; get; } = Guid.NewGuid().ToString();
        public string MealTitle { set; get; }
        public IEnumerable<FoodEntity>Food { set; get; }
    }
}
