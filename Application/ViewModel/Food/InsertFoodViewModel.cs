using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Food
{
    public class InsertFoodViewModel
    {
        [Required(ErrorMessage = "نام غذا الزامی است")]
        public string FoodTitle { set; get; }
        [Required(ErrorMessage = "هزینه غذا الزامی است")]
        public string FoodPrice { set; get; }
        public string FoodDiscountPrice { set; get; }
        [Required(ErrorMessage = "تصویر غذا الزامی است")]
        public IFormFile FoodImage { set; get; }
        [Required(ErrorMessage = "تعداد غذا الزامی است")]
        public string FoodCount { set; get; }
        [Required(ErrorMessage = "برچسب غذا الزامی است")]
        public string FoodTags { set; get; }
        [Required(ErrorMessage = "توصیحات جامع غذا الزامی است")]
        public string FoodDescription { set; get; }
        [Required(ErrorMessage = "توضیح کوتاه غذا الزامی است")]
        public string FoodSummary { set; get; }
        [Required(ErrorMessage = "کالری غذا الزامی است")]
        public string FoodCalories { set; get; }
        [Required(ErrorMessage = "کربوهیدرات غذا الزامی است")]
        public string FoodCarbohydrate { set; get; }
        [Required(ErrorMessage = "چربی غذا الزامی است")]
        public string FoodFat { set; get; }
        [Required(ErrorMessage = "پروتئین غذا الزامی است")]
        public string FoodProtein { set; get; }
        [Required(ErrorMessage = "لینک ویدئو غذا الزامی است")]
        public string FoodLink { set; get; }
        [Required(ErrorMessage = "وعده غذا الزامی است")]
        public string MealId { set; get; }
        [Required(ErrorMessage = "بیماری غذا الزامی است")]
        public string SicknessId { set; get; }
        public int Rate { set; get; }
        [Required(ErrorMessage = " کد غذا الزامی است")]
        public string FoodCode { set; get; }
    }
}
