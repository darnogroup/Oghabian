using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class FoodEntity
    {
        public string FoodId { set; get; } = Guid.NewGuid().ToString();
        public string FoodTitle { set; get; }
        public string FoodPrice { set; get; }
        public string FoodDiscountPrice { set; get; }
        public string FoodImage { set; get; }
        public string FoodCount { set; get; }
        public string FoodTags { set; get; }
        public string FoodDescription { set; get; }
        public string FoodSummary { set; get; }
        public string FoodCalories { set; get; }
        public string FoodCarbohydrate { set; get; }
        public string FoodFat { set; get; }
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
    }
}
