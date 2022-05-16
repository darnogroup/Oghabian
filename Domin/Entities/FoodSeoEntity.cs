using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class FoodSeoEntity
    {
        public int SeoId { set; get; }
        public string GraphTitle { set; get; }
        public string GraphType { set; get; }
        public string GraphUrl { set; get; }
        public string GraphImage { set; get; }
        public string GraphDescription { set; get; }
        public string GraphSiteName { set; get; }
        public string TwitterTitle { set; get; }
        public string TwitterDescription { set; get; }
        public string TwitterImage { set; get; }
        public string Description { set; get; }
        public string FoodId { set; get; }
        public FoodEntity Food { set; get; }
    }
}
