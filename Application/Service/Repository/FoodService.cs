using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Food;
using Application.ViewModel.Selection;
using Application.ViewModel.Sickness;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class FoodService : IFoodService
    {
        private readonly IFoodInterface _food;

        private readonly IGeneralInterface _general;

        public FoodService(IFoodInterface food, IGeneralInterface general)
        {
            _food = food;
            _general = general;
        }
        public Tuple<List<FoodViewModel>, int, int> GetFoods(int page, string search = "")
        {
            int pageSelected = page;
            int count = _food.CountFood().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _food.GetFoods(search, pageSkip).Result;
            List<FoodViewModel> food = new List<FoodViewModel>();

            foreach (var item in list)
            {
                food.Add(new FoodViewModel()
                {
                    FoodPrice = item.FoodPrice,
                    FoodTitle = item.FoodTitle,
                    FoodImage = item.FoodImage,
                    FoodCount = item.FoodCount,
                    FoodId = item.FoodId
                });
            }
            return Tuple.Create(food, count, pageSelected);
        }

        public async Task<UpdateFoodViewModel> GetFoodById(string id)
        {
            var result = await _food.GetFoodById(id);
            UpdateFoodViewModel food = new UpdateFoodViewModel();
            food.SicknessId = result.SicknessId;
            food.MealId = result.MealId;
            food.FoodPrice = result.FoodPrice;
            food.FoodTitle = result.FoodTitle;
            food.FoodImagePath = result.FoodImage;
            food.FoodCount = result.FoodCount;
            food.FoodSummary = result.FoodSummary;
            food.FoodLink = result.FoodLink;
            food.FoodDiscountPrice = result.FoodDiscountPrice;
            food.FoodCalories = result.FoodCalories;
            food.FoodCarbohydrate = result.FoodCarbohydrate;
            food.FoodDescription = result.FoodDescription;
            food.FoodFat = result.FoodFat;
            food.FoodId = result.FoodId;
            food.FoodTags = result.FoodTags;
            food.FoodProtein = result.FoodProtein;
            return food;
        }

        public bool InsertFood(InsertFoodViewModel model)
        {
            FoodEntity food = new FoodEntity();
            food.Time = DateTime.Now;
            food.SicknessId = model.SicknessId;
            food.MealId = model.MealId;
            food.FoodPrice = model.FoodPrice;
            food.FoodTitle = model.FoodTitle;
            food.FoodCount = model.FoodCount;
            food.FoodSummary = model.FoodSummary;
            food.FoodLink = model.FoodLink;
            food.FoodDiscountPrice = model.FoodDiscountPrice;
            food.FoodCalories = model.FoodCalories;
            food.FoodCarbohydrate = model.FoodCarbohydrate;
            food.FoodDescription = model.FoodDescription;
            food.FoodFat = model.FoodFat;
            food.FoodTags = model.FoodTags;
            food.FoodProtein = model.FoodProtein;
            if (model.FoodImage != null)
            {
                var check = model.FoodImage.IsImage();
                if (check)
                {
                    food.FoodImage = ImageProcessing.SaveImage(model.FoodImage);
                }
                else
                {
                    food.FoodImage = "notFound.png";
                }
            }
            else
            {
                food.FoodImage = "notFound.png";
            }

            try
            {
                _food.InsertFood(food);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateFood(UpdateFoodViewModel model)
        {
            var food = _food.GetFoodById(model.FoodId).Result;
            food.SicknessId = model.SicknessId;
            food.MealId = model.MealId;
            food.FoodPrice = model.FoodPrice;
            food.FoodTitle = model.FoodTitle;
            food.FoodCount = model.FoodCount;
            food.FoodSummary = model.FoodSummary;
            food.FoodLink = model.FoodLink;
            food.FoodDiscountPrice = model.FoodDiscountPrice;
            food.FoodCalories = model.FoodCalories;
            food.FoodCarbohydrate = model.FoodCarbohydrate;
            food.FoodDescription = model.FoodDescription;
            food.FoodFat = model.FoodFat;
            food.FoodTags = model.FoodTags;
            food.FoodProtein = model.FoodProtein;
            if (model.FoodImage != null)
            {
                var check = model.FoodImage.IsImage();
                if (check)
                {
                    food.FoodImage = ImageProcessing.SaveImage(model.FoodImage);
                    if (model.FoodImagePath != "notFound.png")
                    {
                        ImageProcessing.RemoveImage(model.FoodImagePath);
                    }
                }
            }

            try
            {
                _food.UpdateFood(food);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteFood(string id)
        {
            var model = _food.GetFoodById(id).Result;
            try
            {
                _food.DeleteFood(model);
                if (model.FoodImage != "notFound.png")
                {
                    ImageProcessing.RemoveImage(model.FoodImage);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<SelectViewModel>> GetMeals()
        {
            var result = await _general.GetMeals();
            List<SelectViewModel>select=new List<SelectViewModel>();
            foreach (var item in result)
            {
                select.Add(new SelectViewModel()
                {
                    Text = item.MealTitle,
                    Value = item.MealId
                });
            }

            return select;
        }

        public async Task<List<SelectViewModel>> GetSickness()
        {
            var result = await _general.GetSickness();
            List<SelectViewModel> select = new List<SelectViewModel>();
            foreach (var item in result)
            {
                select.Add(new SelectViewModel()
                {
                    Text = item.SicknessTitle,
                    Value = item.SicknessId
                });
            }

            return select;
        }
    }
}
