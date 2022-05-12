using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Meal;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class MealService:IMealService
    {
        private readonly IMealInterface _meal;

        public MealService(IMealInterface meal)
        {
            _meal = meal;
        }
        public Tuple<List<MealViewModel>, int, int> GetMeals(int page, string search = "")
        {
            int pageSelected = page;
            int count = _meal.CountMeal().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list = _meal.GetMeals(search, pageSkip).Result;
            List<MealViewModel> meals = new List<MealViewModel>();

            foreach (var item in list)
            {
                meals.Add(new MealViewModel()
                {
                    MealId = item.MealId,
                    MealName = item.MealTitle
                });
            }
            return Tuple.Create(meals, count, pageSelected);
        }

        public async Task<UpdateMealViewModel> GetMealById(string id)
        {
            var result = await _meal.GetMealById(id);
            UpdateMealViewModel model=new UpdateMealViewModel();
            model.MealId = result.MealId;
            model.MealName = result.MealTitle;
            return model;
        }

        public bool InsertMeal(InsertMealViewModel model)
        {
           MealEntity meal=new MealEntity()
           {
               MealTitle = model.MealName
           };
           try
           {
               _meal.InsertMeal(meal);
               return true;
           }
           catch
           {
               return false;
           }
        }

        public bool UpdateMeal(UpdateMealViewModel model)
        {
            var result = _meal.GetMealById(model.MealId).Result;
            result.MealTitle = model.MealName;
            try
            {
                _meal.UpdateMeal(result);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteMeal(string id)
        {
            var result = _meal.GetMealById(id).Result;
            try
            {
                _meal.DeleteMeal(result);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
