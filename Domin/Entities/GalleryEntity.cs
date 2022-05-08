using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class GalleryEntity
    {
        public string ImageId { set; get; } = Guid.NewGuid().ToString();
        public string ImagePath { set; get; }
        public string FoodId { set; get; }
        public FoodEntity Food { set; get; }
    }
}
