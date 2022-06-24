using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Enum;

namespace Domin.Entities
{
    public class FoodEntity
    {
        public string FoodId { set; get; } = Guid.NewGuid().ToString();
        public string FoodTitle { set; get; }
        public int FoodPrice { set; get; }
        public int Rate { set; get; }
        public WeekEnum Day { set; get; }
        public int FoodDiscountPrice { set; get; }
        public string FoodImage { set; get; }
        public string FoodCount { set; get; }
        public string FoodTags { set; get; }
        public string FoodDescription { set; get; }
        public string FoodSummary { set; get; }
        public int FoodCalories { set; get; }
        public string FoodCarbohydrate { set; get; }
        public string FoodFat { set; get; }
        public string FoodCode { set; get; }
        public string FoodProtein { set; get; }
        public string FoodLink { set; get; }
        public DateTime Time { set; get; }
        public string MealId { set; get; }
        public MealEntity Meal { set; get; }
        public string SicknessId { set; get; }
        public SicknessEntity Sickness { set; get; }
        public IEnumerable<PropertyEntity>Properties { set; get; }
        public IEnumerable<GalleryEntity>Gallery { set; get; }
        public IEnumerable<FavoriteEntity>Favorite { set; get; }
        public IEnumerable<CommentFoodEntity>Comment { set; get; }
        public FoodSeoEntity Seo { set; get; }
        public IEnumerable<OrderDetailEntity> OrderDetail { set; get; }
    }
}
