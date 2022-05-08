using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class FavoriteEntity
    {
        public string FavoriteId { set; get; } = Guid.NewGuid().ToString();
        public string FoodId { set; get; }
        public FoodEntity Food { set; get; }
        public string UserId { set; get; }
        public UserEntity User { set; get; }
    }
}
