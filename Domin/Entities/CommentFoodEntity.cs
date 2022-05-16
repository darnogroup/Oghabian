using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class CommentFoodEntity
    {
        public bool Show { set; get; }
        public string CommentId { set; get; } = Guid.NewGuid().ToString();
        public string CommentText { set; get; }
        public DateTime CreateTime { set; get; }=DateTime.Now;
        public string FoodId { set; get; }
        public FoodEntity Food { set; get; }
        public string UserId { set; get; }
        public UserEntity User { set; get; }
    }
}
